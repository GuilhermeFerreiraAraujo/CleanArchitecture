using Cgi.Appmar.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VesselsController : ControllerBase
    {
     
        private readonly ILogger<VesselsController> logger;
        private readonly IVesselServices vesselServices;

        public VesselsController(ILogger<VesselsController> _logger, IVesselServices _vesselServices)
        {
            logger = _logger;
            vesselServices = _vesselServices;
        }

        [HttpGet(Name = "GetVessels")]
        public IEnumerable<Vessel> GetVessels()
        {
            return null;
        }
    }
}