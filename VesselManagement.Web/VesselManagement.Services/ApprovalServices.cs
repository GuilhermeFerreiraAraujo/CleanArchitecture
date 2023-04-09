using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Services
{
    public class ApprovalServices : IApprovalServices
    {
        private readonly IApprovalRepository approvalRepository;

        public ApprovalServices(IApprovalRepository _approvalRepository)
        {
            approvalRepository = _approvalRepository;
        }

        public void ApproveActivity(ApproveActivityRequest request)
        {
            approvalRepository.ApproveActivity(request);
        }

        public List<Approval> GetPendingApprovals()
        {
            return approvalRepository.GetPendingApprovals();
        }

        public void RejectActivity(RejectActivityRequest request)
        {
            approvalRepository.RejectActivity(request);
        }
    }
}