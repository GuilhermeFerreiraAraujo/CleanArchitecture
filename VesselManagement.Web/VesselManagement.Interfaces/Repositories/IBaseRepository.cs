namespace Cgi.Appmar.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> Get();
        void Update(T vessel);
        void Delete(T vessel);
        T Add(T vessel);
    }
}


