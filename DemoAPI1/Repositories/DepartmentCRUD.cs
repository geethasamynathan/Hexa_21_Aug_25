using DemoAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI1.Repositories
{
    public class DepartmentCRUD : IDepartmentCRUD
    {
        private readonly ApplicationDbContext _context;
        public DepartmentCRUD(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            try
            {
                return await _context.Departments.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while fetching all Departments"+e.Message);
            }
        }
        public async Task<Department?> GetDepartmentById(int id)
        {
            try
            {
                return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            }
            catch(Exception e)
            {
                throw new Exception("Error while fetching Department by Id"+e.Message);
            }
        }

        public async Task<Department> AddNewDepartement(Department department)
        {
            try
            {
                if (department == null)
                    throw new ArgumentNullException("Department is null");
                _context.Departments.Add(department); //insert query
                await _context.SaveChangesAsync(); //commit transaction (or) execute the insert the query
                return department;
            }
            catch(Exception e)
            {
                throw new Exception("Error while adding new Department"+e.Message);
            }
        }

        public async Task UpdateDepartement(Department department)
        {
            try
            {
                var dept = await _context.Departments.FirstOrDefaultAsync(d => d.Id == department.Id);
                if (dept == null)
                    throw new Exception($"Department with Id {department.Id} not found");
                dept.DepartmentName = department.DepartmentName;
                dept.Location = department.Location;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while updating Department" + e.Message);
            }
        }
        public async Task DeleteDepartement(int id)
        {
            try
            {
                var dept = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
                if (dept == null)
                    throw new Exception($"Department with Id {id} not found");
                _context.Departments.Remove(dept); //delete query
                await _context.SaveChangesAsync(); //commit transaction (or) execute the delete the query
            }
            catch (Exception e)
            {
                throw new Exception("Error while deleting Department" + e.Message);
            }
        }
    }

}
