using DemoAPI1.Models;

namespace DemoAPI1.Repositories
{
    public interface IEmployeeCRUD
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(int id);
        Task<Employee> AddNewEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<IEnumerable<Employee>> GetEmployeeByDepartment(int departmentId);
    }
}
