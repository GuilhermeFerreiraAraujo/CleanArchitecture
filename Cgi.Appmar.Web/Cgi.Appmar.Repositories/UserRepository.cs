using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cgi.Appmar.Repositories
{
    public class UserRepository : BaseRepository<Vessel>, IUserRepository
    {
        private readonly AppmarContext context;

        public UserRepository(AppmarContext _context) : base(_context)
        {
            context = _context;
        }

        public User Add(User vessel)
        {
            throw new NotImplementedException();
        }

        public void Delete(User vessel)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUser(User user)
        {
            if (context.Users.FirstOrDefault(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash) == null)
            {
                return false;
            };

            return true;
        }

        public void Update(User vessel)
        {
            throw new NotImplementedException();
        }

        User IBaseRepository<User>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IBaseRepository<User>.Get()
        {
            throw new NotImplementedException();
        }
    }
}