using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Services
{
    public interface IApprovalServices
    {
        void ApproveActivity(ApproveActivityRequest request);
        List<Approval> GetPendingApprovals();
        void RejectActivity(RejectActivityRequest request);
    }
}
