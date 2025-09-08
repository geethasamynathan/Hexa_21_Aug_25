using DemoAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI1.Repositories
{
    public class EmployeeCRUD : IEmployeeCRUD
    {
        private readonly ApplicationDbContext _context;
        public EmployeeCRUD(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddNewEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                    throw new ArgumentNullException("Employee is null");
                var deptExists=await  _context.Departments.AnyAsync(d => d.Id == employee.DepartmentId);
                if(!deptExists)
                    throw new Exception($"Department with Id {employee.DepartmentId} not found");
                _context.Employees.Add(employee); //insert query
                await _context.SaveChangesAsync(); //commit transaction (or) execute the insert the query
                return employee;
            }
            catch(Exception e)
            {
                throw new Exception("Error while adding new Employee"+e.Message);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                var existing = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);  
                if(existing == null )
                    throw new Exception($"Employee with Id {id} not found");
                await _context.Employees.Where(e => e.EmployeeId == id).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while deleting Employee" + e.Message);
            }   
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return await _context.Employees.
                    Include(e => e.Department)
                    .AsNoTracking().
                    ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while fetching all Employees" + e.Message);
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartment(int departmentId)
        {
            try
            {
                return await _context.Employees.
                    Where(e => e.DepartmentId == departmentId).
                    Include(e => e.Department).
                    AsNoTracking().
                    ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while fetching Employees by Department" + e.Message);
            }
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            try
            {
                return await _context.Employees.
                    Include(e => e.Department).
                    FirstOrDefaultAsync(e => e.EmployeeId == id);
            }
            catch(Exception e)
            {
                throw new Exception("Error while fetching Employee by Id" + e.Message);
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                var existing= await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
                if(existing == null)
                    throw new Exception($"Employee with Id {employee.EmployeeId} not found");
                if(existing.DepartmentId != employee.DepartmentId)
                {
                    var deptExists = await _context.Departments.AnyAsync(d => d.Id == employee.DepartmentId);
                    if (!deptExists)
                        throw new Exception($"Department with Id {employee.DepartmentId} not found");
                }
                existing.Name = employee.Name;
                existing.Gender = employee.Gender;
                existing.Location = employee.Location;
                existing.DepartmentId = employee.DepartmentId;
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Error while updating Employee" + e.Message);
            }
        }
    }
}
