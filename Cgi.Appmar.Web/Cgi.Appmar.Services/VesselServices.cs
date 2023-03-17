using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Services
{
    public class VesselServices : IVesselServices
    {
        private readonly IVesselRepository vesselRepository;

        public VesselServices(IVesselRepository _vesselRespotirory)
        {
            vesselRepository = _vesselRespotirory;
        }

        public Vessel AddVessel(AddVesselRequest request)
        {
            var vessel = new Vessel
            {
                Name = request.Name
            };

            return vesselRepository.Add(vessel);
        }

        public Vessel GetVesselById(int id)
        {
            return vesselRepository.Get(id);
        }

        public IEnumerable<Vessel> GetVessels()
        {
            return vesselRepository.Get();
        }

        public void UpdateVessel(UpdateVesselRequest request)
        {
            var vessel = new Vessel
            {
                Name = request.Name
            };

            vesselRepository.Update(vessel);
        }
    }
}