using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Services
{
    public interface IUserServices
    {
        void Authenticate(AuthenticateRequest request);

        User AddUser(AddUserRequest request);
    }
}
