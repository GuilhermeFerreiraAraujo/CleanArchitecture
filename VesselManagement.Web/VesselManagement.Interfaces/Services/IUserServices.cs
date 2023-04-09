using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Services
{
    public interface IUserServices
    {
        void Authenticate(AuthenticateRequest request);
        User AddUser(AddUserRequest request);
        void UpdateUser(UpdateUserRequest request);
        User GetUserById(int id);
        List<User> GetUsers(GetUsersRequest request);
    }
}
