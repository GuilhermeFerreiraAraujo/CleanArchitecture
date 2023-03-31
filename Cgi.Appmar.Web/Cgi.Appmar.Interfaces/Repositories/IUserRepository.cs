using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> GetUsers(GetUsersRequest request);
        bool IsValidUser(User user);
    }
}
