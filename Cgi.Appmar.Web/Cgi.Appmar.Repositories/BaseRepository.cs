using Cgi.Appmar.Models;
using Cgi.Appmar.Models.Entities;

namespace Cgi.Appmar.Repositories
{
    public class BaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppmarContext context;

        public BaseRepository(AppmarContext _context)
        {
            context = _context;
        }

        public T Add (T vessel)
        {
            context.Add(vessel);
            context.SaveChanges();
            return vessel;
        }

        public void Delete(T vessel)
        {
            context.Remove(vessel);
            context.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().First(x => x.Id == id);
        }

        public void Update(T vessel)
        {
            context.Set<T>().Update(vessel);
            context.SaveChanges();
        }
    }
}
