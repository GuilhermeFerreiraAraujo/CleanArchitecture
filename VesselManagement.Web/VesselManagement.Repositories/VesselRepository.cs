using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Models.Entities;

namespace Cgi.Appmar.Repositories
{
    public class VesselRepository : BaseRepository<Vessel>, IVesselRepository
    {
        private readonly AppmarContext context;

        public VesselRepository(AppmarContext _context) : base(_context)
        {
            context = _context;
        }
    }
}