using Microsoft.EntityFrameworkCore;
using RouteDemo.Models;

namespace RouteDemo.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly HexaMay25ApiCfDbContext _context;
        public StudentRepo(HexaMay25ApiCfDbContext context)
        {
            _context = context;  
        }
        public async Task<Student> AddStudent(Student student)
        {
            if(student!= null)
            {
               _context.Students.Add(student);
                _context.SaveChanges();
            }
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
           if(id > 0)
            {
                var student = await _context.Students.FindAsync(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
                return student;
            }
            return null;
        }

        public async Task<List<Student>> GetAllStudents()
        {
           return await _context.Students.ToListAsync();
        }

        public Task<List<Student>> GetStudentByAge(int age)
        {
           var studentList= _context.Students.Where(s => s.Age == age).ToListAsync();
            return studentList;
        }

        public async Task<List<Student>> GetStudentByGenderandCity(string? gender, string? city)
        {
            IQueryable<Student> query = _context.Students;
            var filteredStudents=new List<Student>();
            if (!string.IsNullOrWhiteSpace(gender))
            {
                filteredStudents = await query.Where(s => s.Gender == gender).ToListAsync();
            }
            if(!string.IsNullOrEmpty(city))
            { 
                filteredStudents = await _context.Students.Where(s => s.City ==city).ToListAsync();               
            }
            if(!string.IsNullOrEmpty(gender)&& !string.IsNullOrEmpty(city))
            {
                filteredStudents= await _context.Students.Where( s => s.Gender == gender  
                && s.City == city).ToListAsync();
            }
            if(filteredStudents.Count == 0)
            {
              return await _context.Students.ToListAsync();
            }
            else
            {
              return filteredStudents;
            }

        }

        public async Task<Student> GetStudentById(int id)
        {
           var student=await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id   );
            if(student != null)
            {
                return student;
            }
            return null;
        }

        public async Task<List<Student>> SearchStudents(StudentSearch studentSearch)
        {
            var filteredStudents = new List<Student>();
            if (!string.IsNullOrEmpty(studentSearch.Name))
                filteredStudents = await _context.Students.Where(s => s.StudentName.Contains(studentSearch.Name,
                    StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (!string.IsNullOrEmpty(studentSearch.Gender))
                filteredStudents = await _context.Students.Where(s =>
                s.Gender.Equals(studentSearch.Gender, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (!string.IsNullOrEmpty(studentSearch.City))
                filteredStudents = await _context.Students.Where(s =>
                s.City.Equals(studentSearch.City, StringComparison.OrdinalIgnoreCase)).ToListAsync();

            if (!filteredStudents.Any())
            {
                return null;
            }
            else

                return filteredStudents;
        }



        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var studentToUpdate = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (studentToUpdate != null && student != null)
            {
                studentToUpdate.StudentName = student.StudentName;
                studentToUpdate.Gender = student.Gender;
                studentToUpdate.Age = student.Age;
                studentToUpdate.City = student.City;
                studentToUpdate.CourseId = student.CourseId;
                _context.SaveChangesAsync();
            }
            if (studentToUpdate == null)
            {
                return null;
            }
            else

                return studentToUpdate;
        }
        }
    }
