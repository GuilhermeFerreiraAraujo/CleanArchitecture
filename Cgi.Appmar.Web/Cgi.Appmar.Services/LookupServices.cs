using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Services
{
    public class LookupServices : ILookupServices
    {
        private readonly ILookupRepository lookupRepository;

        public LookupServices(ILookupRepository _lookupRepository)
        {
            lookupRepository = _lookupRepository;
        }

        public void AddLookupValue(AddLookupValueRequest request)
        {
            var value = new LookupValue
            {
                LookupId = request.LookupId,
                Value = request.LookupValue,
            };

            lookupRepository.AddLookupValue(value);
        }

        public List<Lookup> GetLookups()
        {
            return lookupRepository.Get().ToList();
        }

        public List<LookupValue> GetLookupValues(int id)
        {
            return lookupRepository.GetLookupValues(id);
        }

        public void RemoveLookupValue(RemoveLookupValueRequest request)
        {
            lookupRepository.RemoveLookupValue(request);
        }

        public void UpdateLookupValue(UpdateLookupValueRequest request)
        {
            lookupRepository.UpdateLookupValue(request);
        }
    }
}