using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Repositories
{
    public class ApprovalRepository : BaseRepository<Approval>, IApprovalRepository
    {
        private readonly AppmarContext context;

        public ApprovalRepository(AppmarContext _context) : base(_context)
        {
            context = _context;
        }

        public void ApproveActivity(ApproveActivityRequest request)
        {
            var approval = context.Approvals.First(x => x.Id == request.ApprovalId);
            approval.IsActive = false;
            approval.IsApproved = false;
            approval.Comment = request.Reason;

            context.Approvals.Update(approval);
            context.SaveChanges();
        }

        public List<Approval> GetPendingApprovals()
        {
            return context.Approvals.Where(x => x.IsActive == true).ToList();
        }

        public void RejectActivity(RejectActivityRequest request)
        {
            var approval = context.Approvals.First(x => x.Id == request.ApprovalId);

            approval.IsActive = false;
            approval.IsApproved = false;
            approval.Comment = request.Reason;

            context.SaveChanges();
        }
    }
}