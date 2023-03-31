using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        public async Task<IActionResult>SignInAsync([FromBody]AuthenticateRequest request)
        {
            userServices.Authenticate(request);
            return Ok();
        }

        [Route("GetUserById")]
        [HttpGet]
        public async Task<IActionResult>GetUserById(int id)
        {
            var user = userServices.GetUserById(id);
            return Ok(user);
        }

        [Route("GetUsers")]
        [HttpPost]
        public async Task<IActionResult>GetUsers([FromBody]GetUsersRequest request)
        {
            var users = userServices.GetUsers(request);
            return Ok(users);
        }


        [Route("AddUser")]
        [HttpPost]
        public IActionResult AddUser([FromBody]AddUserRequest request)
        {
            userServices.AddUser(request);
            return Ok();
        }

        [Route("UpdateUser")]
        [HttpPost]
        public IActionResult UpdateUser([FromBody]UpdateUserRequest request)
        {
            userServices.UpdateUser(request);
            return Ok();
        }
    }
}