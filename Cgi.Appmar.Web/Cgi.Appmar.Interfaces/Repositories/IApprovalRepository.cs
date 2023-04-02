using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Repositories
{
    public interface IApprovalRepository : IBaseRepository<Approval>
    {
        void ApproveActivity(ApproveActivityRequest request);
        List<Approval> GetPendingApprovals();
        void RejectActivity(RejectActivityRequest request);
    }
}
