using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmissionAPI.Models;

namespace SchoolAdmissionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionsController : ControllerBase
    {
        static List<StudentAdmissionModel> studentAdmissions = new List<StudentAdmissionModel>
        {
            new StudentAdmissionModel { StudentId = 1, StudentName = "Alice", Grade = "5th", AdmissionDate = DateTime.Now.AddDays(-10) },
            new StudentAdmissionModel { StudentId = 2, StudentName = "Bob", Grade = "6th", AdmissionDate = DateTime.Now.AddDays(-20) },
            new StudentAdmissionModel { StudentId = 3, StudentName = "Ashok", Grade = "5th", AdmissionDate = DateTime.Now.AddDays(-10) },
            new StudentAdmissionModel { StudentId = 4, StudentName = "Divyasri", Grade = "6th", AdmissionDate = DateTime.Now.AddDays(-20) },
            new StudentAdmissionModel { StudentId = 5, StudentName = "Madhu Sai", Grade = "5th", AdmissionDate = DateTime.Now.AddDays(-10) },
            new StudentAdmissionModel { StudentId = 6, StudentName = "Jeeva", Grade = "6th", AdmissionDate = DateTime.Now.AddDays(-20) }
        };
        [HttpGet]
        public async Task<List<StudentAdmissionModel>> GetAllAdmissions()
        {
           if(studentAdmissions == null || studentAdmissions.Count == 0)
            {
                return null;
            }
            return await Task.FromResult(studentAdmissions);
        }
    }
}
