using Cgi.Appmar.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IUserServices userServices;

        public UsersController(ILogger<UsersController> _logger, 
            IUserServices _userServices)
        {
            logger = _logger;
            userServices = _userServices;
        }

        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignInAsync([FromBody]AuthenticateRequest request)
        {
            userServices.Authenticate(request);
            return Ok();
        }

        [Route("AddUser")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddUser([FromBody]AddUserRequest request)
        {

            userServices.AddUser(request);

            return Ok();

        }
    }
}