using DemoAPI1.Models;
using DemoAPI1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeCRUD _employeeCRUD;

        public EmployeesController(IEmployeeCRUD employeeCRUD)
        {
            _employeeCRUD = employeeCRUD;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeCRUD.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var department = await _employeeCRUD.GetEmployeeById(id);
            if (department == null)
                return NotFound($"Employee with Id {id} not found");
            return Ok(department);
        }
        [HttpGet("by-department/{departmentId}")]
        public async Task<IActionResult> GetEmployeesByDepartmentId(int departmentId)
        {
            var department = await _employeeCRUD.GetEmployeeByDepartment(departmentId);
            if (department == null)
                return NotFound($"Employee with Id {departmentId} not found");
            return Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(Employee employee)
        {
            var newEmployee = await _employeeCRUD.AddNewEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, newEmployee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeCRUD.UpdateEmployee(employee);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeCRUD.DeleteEmployee(id);
            return NoContent();
        }
    }
}
