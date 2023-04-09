using Cgi.Appmar.Interfaces.Services;
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
        private readonly IRoleServices roleServices;

        public RolesController(ILogger<VesselsController> _logger, IRoleServices _roleServices)
        {
            logger = _logger;
            roleServices = _roleServices;
        }

        [Route("AddRole")]
        [HttpPost]
        public IActionResult AddRoles([FromBody]AddRoleRequest request)
        {
            var role = roleServices.AddRole(request);

            return Ok(role); 
        }

        [Route("GetRoleById")]
        [HttpGet]
        public IActionResult GetRoleById(int id)
        {
            var role = roleServices.GetRoleById(id);
            return Ok(role);
        }

        [HttpPost]
        [Route("UpdateRole")]
        public IActionResult UpdateRole([FromBody]UpdateRoleRequest request)
        {
            roleServices.Update(request);
            return Ok(request.Id);
        }

        [HttpPost]
        [Route("UpdateRolePermissions")]
        public IActionResult UpdateRolePermissions([FromBody]UpdateRolePermissionsRequest request)
        {
            roleServices.UpdateRolePermissions(request);
            return Ok(request.RoleId);
        }
    }
}