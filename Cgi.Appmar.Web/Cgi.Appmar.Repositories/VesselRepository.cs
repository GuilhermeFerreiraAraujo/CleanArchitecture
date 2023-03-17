using Cgi.Appmar.Interfaces.Repositories;

namespace Cgi.Appmar.Repositories
{
    public class VesselRepository : IVesselRepository
    {

        private readonly AppmarContext context;
        public VesselRepository(AppmarContext _context)
        {
            context = _context;
        }

        public IEnumerable<Vessel> GetVessels()
        {
            return context.Vessels.ToList();
        }
    }
}