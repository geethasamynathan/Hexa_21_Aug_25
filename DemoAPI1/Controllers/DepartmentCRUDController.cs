using DemoAPI1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentCRUDController : ControllerBase
    {
        private readonly IDepartmentCRUD _departmentCRUD;

        public DepartmentCRUDController(IDepartmentCRUD departmentCRUD )
        {
            _departmentCRUD = departmentCRUD;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentCRUD.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]   
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentCRUD.GetDepartmentById(id);
            if (department == null)
                return NotFound($"Department with Id {id} not found");
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDepartment([FromBody] Models.Department department)
        {
            var newDepartment = await _departmentCRUD.AddNewDepartement(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = newDepartment.Id }, newDepartment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] Models.Department department)
        {
            await _departmentCRUD.UpdateDepartement(department);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentCRUD.DeleteDepartement(id);
            return NoContent();
        }

    }
}
