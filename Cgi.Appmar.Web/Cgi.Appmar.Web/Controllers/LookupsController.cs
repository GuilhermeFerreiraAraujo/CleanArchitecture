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

        public DocumentsController(ILogger<DocumentsController> _logger)
        {
            logger = _logger;
        }
    }
}