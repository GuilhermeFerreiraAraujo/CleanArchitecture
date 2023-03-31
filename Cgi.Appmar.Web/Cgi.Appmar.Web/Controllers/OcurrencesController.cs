using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FeesController : ControllerBase
    {
        private readonly ILogger<FeesController> logger;

        public FeesController(ILogger<FeesController> _logger)
        {
            logger = _logger;
        }
    }
}