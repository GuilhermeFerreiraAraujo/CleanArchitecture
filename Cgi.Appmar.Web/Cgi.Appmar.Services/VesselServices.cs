using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;

namespace Cgi.Appmar.Services
{
    public class VesselServices : IVesselServices
    {

        private readonly IVesselRepository vesselRepository;

        public VesselServices(IVesselRepository _vesselRespotirory)
        {
            vesselRepository = _vesselRespotirory;
        }
    }
}