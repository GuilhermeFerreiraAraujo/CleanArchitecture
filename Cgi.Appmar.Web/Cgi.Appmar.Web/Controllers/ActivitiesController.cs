using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OcurrencesController : ControllerBase
    {
        private readonly ILogger<OcurrencesController> logger;

        public OcurrencesController(ILogger<OcurrencesController> _logger)
        {
            logger = _logger;
        }
    }
}