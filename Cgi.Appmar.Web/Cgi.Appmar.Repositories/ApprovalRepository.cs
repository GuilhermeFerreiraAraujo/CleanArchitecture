using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Models.Entities;

namespace Cgi.Appmar.Repositories
{
    public class ApprovalRepository : BaseRepository<Approval>, IApprovalRepository
    {
        private readonly AppmarContext context;

        public ApprovalRepository(AppmarContext _context) : base(_context)
        {
            context = _context;
        }
    }
}