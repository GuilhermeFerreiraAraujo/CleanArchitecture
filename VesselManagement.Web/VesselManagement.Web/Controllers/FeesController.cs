using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LookupsController : ControllerBase
    {
        private readonly ILogger<LookupsController> logger;

        public LookupsController(ILogger<LookupsController> _logger)
        {
            logger = _logger;
        }
    }
}