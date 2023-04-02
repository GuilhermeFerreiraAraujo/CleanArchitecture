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

        private readonly

        public ApprovalsController(ILogger<ApprovalsController> _logger)
        {
            logger = _logger;
        }

        [Route("GetPendingApprovals")]
        [HttpGet]
        public IActionResult GetPendingApprovals()
        {
            return Ok(); 
        }

        [HttpPost]
        [Route("ApproveActivity")]
        public IActionResult ApproveActivity([FromBody] UpdateVesselRequest request)
        {
            return Ok();
        }

        [HttpPost]
        [Route("RejectActivity")]
        public IActionResult RejectActivity([FromBody] AddVesselRequest request)
        {
            return Ok();
        }
    }
}