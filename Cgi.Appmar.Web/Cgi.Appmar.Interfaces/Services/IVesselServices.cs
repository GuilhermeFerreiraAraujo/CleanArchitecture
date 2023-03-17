using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Services
{
    public interface IVesselServices
    {
        Vessel AddVessel(AddVesselRequest request);
        Vessel GetVesselById(int id);
        IEnumerable<Vessel> GetVessels();
        void UpdateVessel(UpdateVesselRequest request);
    }
}
