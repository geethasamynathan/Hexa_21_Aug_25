using RouteDemo.Models;

namespace RouteDemo.Repository
{
    public interface IStudentRepo
    {
        public Task<List<Student>> GetAllStudents();
        public Task<Student> GetStudentById(int id);
        public Task<Student> AddStudent(Student student);
        public Task<Student> UpdateStudent(int id, Student student);
        public Task<Student> DeleteStudent(int id);
        public Task<List<Student>> GEtStudentByName(string name);
        public Task<List<Student>> GetStudentByAge(int age);
        public Task<List<Student>> GetStudentByGenderandCity(string? gender,string? city);
        public Task<List<Student>> SearchStudents(StudentSearch studentSearch);
    }
}
