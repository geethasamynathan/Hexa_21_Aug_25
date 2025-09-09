using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteDemo.Repository;

namespace RouteDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        public StudentsController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        //[HttpGet("All")]
        //[HttpGet("AllStudents")]
        //[HttpGet("~/api/All")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepo.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("getbyage/{age}")]
        public async Task<IActionResult> GetStudentByAge(int age)
        {
            var student = await _studentRepo.GetStudentByAge(age);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("SearchByGenderCity")]
        public async Task<IActionResult> GetStudentByGenderandCity([FromQuery] string? gender, [FromQuery] string? city)
        {
            var students= await _studentRepo.GetStudentByGenderandCity(gender, city);
            if(students == null || students.Count == 0  )
            {
                return NotFound();
            }
            else
            {
                return Ok(students);
            }
        }

    }
}
