using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        private readonly ILogger<ActivitiesController> logger;

        public ActivitiesController(ILogger<ActivitiesController> _logger)
        {
            logger = _logger;
        }
    }
}