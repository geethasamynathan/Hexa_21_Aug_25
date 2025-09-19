using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace versioningdemo.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class MyController2 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"2. 0 This is API version {HttpContext.GetRequestedApiVersion()}");
        }
    }
}
