using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Services
{
    public interface ILookupServices
    {
        void AddLookupValue(AddLookupValueRequest request);
        List<Lookup> GetLookups();
        List<LookupValue> GetLookupValues(int id);
        void RemoveLookupValue(RemoveLookupValueRequest request);
        void UpdateLookupValue(UpdateLookupValueRequest request);
    }
}
