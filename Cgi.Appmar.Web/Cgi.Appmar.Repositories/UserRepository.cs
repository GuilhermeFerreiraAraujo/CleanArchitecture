using Cgi.Appmar.Interfaces.Repositories;

namespace Cgi.Appmar.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppmarContext context;

        public UserRepository(AppmarContext _context) : base(_context)
        {
            context = _context;
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