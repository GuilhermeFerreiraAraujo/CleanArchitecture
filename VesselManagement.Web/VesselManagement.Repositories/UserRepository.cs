﻿using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppmarContext context;

        public UserRepository(AppmarContext _context) : base(_context)
        {
            context = _context;
        }

        public List<User> GetUsers(GetUsersRequest request)
        {
            var users = context.Users.Where(x => x.Id > 0);

            if (!string.IsNullOrEmpty(request.Name))
            {
                users = users.Where(x => x.Name.Contains(request.Name));
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                users = users.Where(x => x.Email.Contains(request.Email));
            }

            if (!request.IsActive == null)
            {
                users = users.Where(x => x.IsActive == request.IsActive);
            }

            return users.ToList();
        }

        public bool IsValidUser(User user)
        {
            if (context.Users.FirstOrDefault(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash) == null)
            {
                return false;
            };

            return true;
        }
    }
}