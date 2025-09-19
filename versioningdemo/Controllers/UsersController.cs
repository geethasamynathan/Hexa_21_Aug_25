//using Asp.Versioning;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace versioningdemo.Controllers
//{
//    [ApiController]
//    [ApiVersion("1.0")]
//    [ApiVersion("2.0")]  
//    [Route("api/v{version:apiVersion}/users")] // URI Versioning
//    //[Route("api/users")] // QueryString & Header & MediaType Versioning
//    public class UsersController : Controller
//    {
//        [HttpGet]
//        [MapToApiVersion("1.0")]
//        public IActionResult GetUsers()
//        {
//            var users = new[] { new { Id = 1, Name = "John Doe" } };
//            return Ok(users);
//        }
//        [HttpGet]
//        [MapToApiVersion("2.0")]
//        public IActionResult GetUsersV2()
//        {
//            var users = new[] { new { Id = 1, Name = "John Doe", Email = "john.doe@example.com" } };
//            return Ok(users);
//        }
//    }

//}
