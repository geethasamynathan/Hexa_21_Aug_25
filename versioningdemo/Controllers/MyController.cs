using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace versioningdemo.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"This is API version  1.0  -- {HttpContext.GetRequestedApiVersion()}");
        }
    }
}
