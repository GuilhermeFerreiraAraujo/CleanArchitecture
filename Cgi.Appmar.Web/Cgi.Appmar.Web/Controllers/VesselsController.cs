using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class VesselsController : ControllerBase
    {
        private readonly ILogger<VesselsController> logger;
        private readonly IVesselServices vesselServices;

        public VesselsController(ILogger<VesselsController> _logger, IVesselServices _vesselServices)
        {
            logger = _logger;
            vesselServices = _vesselServices;
        }

        [Route("GetVessels")]
        [HttpGet]
        public IActionResult GetVessels()
        {
            return Ok(vesselServices.GetVessels()); 
        }

        [Route("GetVesselById")]
        [HttpGet]
        public IActionResult GetVesselById(int id)
        {
            var vessel = vesselServices.GetVesselById(id);
            return Ok(vessel);
        }

        [HttpPut]
        [Route("UpdateVessel")]
        public IActionResult UpdateVessel([FromBody] UpdateVesselRequest request)
        {
            vesselServices.UpdateVessel(request);
            return Ok();
        }

        [HttpPost]
        [Route("AddVessel")]
        public IActionResult AddVessel([FromBody] AddVesselRequest request)
        {
            var vessel = vesselServices.AddVessel(request);
            return Ok(vessel);
        }
    }
}