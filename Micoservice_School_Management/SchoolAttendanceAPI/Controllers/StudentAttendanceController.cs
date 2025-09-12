using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        static List<Models.StudentAttendance> studentAttendances = new List<Models.StudentAttendance>
        {
            new Models.StudentAttendance { StudentId = 1, StudentName = "Alice", AttendancePercentage = 95.5 },
            new Models.StudentAttendance { StudentId = 2, StudentName = "Bob", AttendancePercentage = 88.0 },
            new Models.StudentAttendance { StudentId = 3, StudentName = "Ashok", AttendancePercentage = 92.3 },
            new Models.StudentAttendance { StudentId = 4, StudentName = "Divyasri", AttendancePercentage = 85.7 },
            new Models.StudentAttendance { StudentId = 5, StudentName = "Madhu Sai", AttendancePercentage = 90.1 },
            new Models.StudentAttendance { StudentId = 6, StudentName = "Jeeva", AttendancePercentage = 87.4 }
        };
        [HttpGet]
        public async Task<List<Models.StudentAttendance>> GetAllAttendances()
        {
            if (studentAttendances == null || studentAttendances.Count == 0)
            {
                return null;
            }
            return await Task.FromResult(studentAttendances);
        }
    }
}
