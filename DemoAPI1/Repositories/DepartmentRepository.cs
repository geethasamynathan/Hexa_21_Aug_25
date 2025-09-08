using DemoAPI1.Models;

namespace DemoAPI1.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly  static List<Department> departments = new List<Department>
        {
             new Department(){Id=1,DepartmentName="IT",Location="Bangalore"},
            new Department(){Id=2,DepartmentName="HR",Location="Chennai"},
            new Department(){Id=3,DepartmentName="Finance",Location="Hyderabad"},
            new Department(){Id=4,DepartmentName="Admin",Location="Pune"},
        };
        public IEnumerable<Department> GetAll() => departments;
           
        public void AddNewDepartment(Department department)
        {
            
            try
            {
                if (department == null)
                    throw new ArgumentNullException("Department is null");
                departments.Add(department);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public Department? GetById(int id) => departments.FirstOrDefault(d => d.Id == id);
        public void UpdateDepartment(Department department)
        {
            try
            {
                var dept = departments.FirstOrDefault(d => d.Id == department.Id);
                if (dept == null)
                    throw new Exception($"Department with Id {department.Id} not found");
                dept.DepartmentName = department.DepartmentName;
                dept.Location = department.Location;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }   
        }

        public void DeleteDepartment(int id)
        {
            try
            {
                var dept = departments.FirstOrDefault(d => d.Id == id);
                if (dept == null)
                    throw new Exception($"Department with Id {id} not found");
                departments.Remove(dept);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }   
    }
}
