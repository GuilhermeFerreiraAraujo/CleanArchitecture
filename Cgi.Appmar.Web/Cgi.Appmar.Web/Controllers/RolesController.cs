using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<VesselsController> logger;

        public RolesController(ILogger<VesselsController> _logger)
        {
            logger = _logger;
        }

        [Route("AddRoles")]
        [HttpGet]
        public IActionResult AddRoles()
        {
            return Ok(); 
        }

        [Route("GetRoleById")]
        [HttpGet]
        public IActionResult GetRoleById(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("EditRoles")]
        public IActionResult UpdateVessel([FromBody] UpdateVesselRequest request)
        {
            return Ok();
        }

        [HttpPost]
        [Route("AddRolePermissions")]
        public IActionResult AddVessel([FromBody] AddVesselRequest request)
        {
            return Ok();
        }
    }
}