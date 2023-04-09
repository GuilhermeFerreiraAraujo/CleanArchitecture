using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> logger;

        public ContactsController(ILogger<ContactsController> _logger)
        {
            logger = _logger;
        }
    }
}