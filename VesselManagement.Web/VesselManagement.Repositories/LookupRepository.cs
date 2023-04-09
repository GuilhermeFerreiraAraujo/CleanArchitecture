using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Repositories
{
    public class LookupRepository : BaseRepository<Lookup>, ILookupRepository
    {
        private readonly AppmarContext context;

        public LookupRepository(AppmarContext _context) : base(_context)
        {
            context = _context;
        }

        public void AddLookupValue(LookupValue value)
        {
            context.LookupValues.Add(value);
        }

        public List<LookupValue> GetLookupValues(int id)
        {
            return context.LookupValues.Where(x => x.LookupId == id).ToList();
        }

        public void RemoveLookupValue(RemoveLookupValueRequest request)
        {
            var value = context.LookupValues.Where(x => x.Id == request.LookupValueId).First();
            context.LookupValues.Remove(value);
            context.SaveChanges();
        }

        public void UpdateLookupValue(UpdateLookupValueRequest request)
        {
            var value = context.LookupValues.First(x => x.Id == request.LookupValueId);
            value.Value = request.LookupValue;
            context.LookupValues.Update(value);
        }
    }
}