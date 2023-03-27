namespace Cgi.Appmar.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool IsValidUser(User user);
    }
}
