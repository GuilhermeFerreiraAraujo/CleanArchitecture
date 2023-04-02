using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Repositories
{
    public interface ILookupRepository : IBaseRepository<Lookup>
    {
        void AddLookupValue(LookupValue value);
        List<LookupValue> GetLookupValues(int id);
        void RemoveLookupValue(RemoveLookupValueRequest request);
        void UpdateLookupValue(UpdateLookupValueRequest request);
    }
}
