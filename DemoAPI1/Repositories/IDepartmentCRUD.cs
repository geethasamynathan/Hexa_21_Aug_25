using DemoAPI1.Models;

namespace DemoAPI1.Repositories
{
    public interface IDepartmentCRUD
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department?> GetDepartmentById(int id);
        Task<Department> AddNewDepartement(Department department );
        Task UpdateDepartement(Department department);
        Task DeleteDepartement(int id);
    }
}
