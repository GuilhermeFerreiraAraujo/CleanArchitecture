using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ApprovalsController : ControllerBase
    {
        private readonly ILogger<ApprovalsController> logger;
        private readonly IApprovalServices approvalServices;

        public ApprovalsController(ILogger<ApprovalsController> _logger)
        {
            logger = _logger;
        }

        [Route("GetPendingApprovals")]
        [HttpGet]
        public IActionResult GetPendingApprovals()
        {
            var approvals = approvalServices.GetPendingApprovals();
            return Ok(approvals); 
        }

        [HttpPost]
        [Route("ApproveActivity")]
        public IActionResult ApproveActivity([FromBody]ApproveActivityRequest request)
        {
            approvalServices.ApproveActivity(request);
            return Ok();
        }

        [HttpPost]
        [Route("RejectActivity")]
        public IActionResult RejectActivity([FromBody]RejectActivityRequest request)
        {
            approvalServices.RejectActivity(request);
            return Ok();
        }
    }
}