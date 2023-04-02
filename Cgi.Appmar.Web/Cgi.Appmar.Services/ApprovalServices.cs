using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;

namespace Cgi.Appmar.Services
{
    public class ApprovalServices : IApprovalServices
    {
        private readonly IApprovalRepository approvalRepository;

        public ApprovalServices(IApprovalRepository _approvalRepository)
        {
            approvalRepository = _approvalRepository;
        }
    }
}