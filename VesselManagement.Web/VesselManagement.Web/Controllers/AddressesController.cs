using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AddressesController : ControllerBase
    {
        private readonly ILogger<AddressesController> logger;

        public AddressesController(ILogger<AddressesController> _logger)
        {
            logger = _logger;
        }
    }
}