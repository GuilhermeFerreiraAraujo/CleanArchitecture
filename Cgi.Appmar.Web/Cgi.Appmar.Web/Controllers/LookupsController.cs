using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cgi.Appmar.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly ILogger<DocumentsController> logger;
        private readonly ILookupServices lookupServices;
        public DocumentsController(ILogger<DocumentsController> _logger, ILookupServices _lookupServices)
        {
            logger = _logger;
            lookupServices = _lookupServices;
        }

        [HttpGet]
        [Route("GetLookups")]
        public IActionResult GetLookups()
        {
            var lookups = lookupServices.GetLookups();
            return Ok(lookups);
        }

        [HttpGet]
        [Route("GetLookupValues")]
        public IActionResult GetLookupValues(int id)
        {
            var values = lookupServices.GetLookupValues(id);
            return Ok(values);
        }

        [HttpPost]
        [Route("AddLookupValue")]
        public IActionResult AddLookupValue([FromBody]AddLookupValueRequest request)
        {
            lookupServices.AddLookupValue(request);
            return Ok();
        }

        [HttpPost]
        [Route("RemoveLookupValue")]
        public IActionResult RemoveLookupValue([FromBody]RemoveLookupValueRequest request)
        {
            lookupServices.RemoveLookupValue(request);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateLookupValue")]
        public IActionResult UpdateLookupValue([FromBody] UpdateLookupValueRequest request)
        {
            lookupServices.UpdateLookupValue(request);
            return Ok();
        }
    }
}