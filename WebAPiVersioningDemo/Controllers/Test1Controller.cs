using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPiVersioningDemo.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    //[Route("api/[controller]")]   
    public class Test1Controller : ControllerBase
    {

        [HttpGet]
        // Version 1.0 is optional and Api can work without Here
        [MapToApiVersion("1.0")]
        public IActionResult GetUsers()
        {
            var users = new[] { new { Id = 1, Name = "John Doe" } };
            return Ok(users);
        }
        [HttpGet("2")]
        [MapToApiVersion("2.0")]
        public IActionResult GetUsersV2()
        {
            var users = new[] { new { Id = 1, Name = "John Doe", Email = "john.doe@example.com" } };
            return Ok(users);
        }
    }
}
