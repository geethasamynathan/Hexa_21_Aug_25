using DemoAPI1.Models;

namespace DemoAPI1.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();

      //  List<Department> GetAllDepartments();
        Department? GetById(int id);
        void AddNewDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);

    }
}
