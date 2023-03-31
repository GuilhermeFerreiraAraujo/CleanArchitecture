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

        public ApprovalsController(ILogger<ApprovalsController> _logger)
        {
            logger = _logger;
        }

        [Route("GetPendingApprovals")]
        [HttpGet]
        public IActionResult GetVessels()
        {
            return Ok(); 
        }


        [HttpPost]
        [Route("ApproveActivity")]
        public IActionResult UpdateVessel([FromBody] UpdateVesselRequest request)
        {
            return Ok();
        }

        [HttpPost]
        [Route("RejectActivity")]
        public IActionResult AddVessel([FromBody] AddVesselRequest request)
        {
            return Ok();
        }
    }
}