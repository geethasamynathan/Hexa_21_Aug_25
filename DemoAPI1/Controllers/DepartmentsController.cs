using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoAPI1.Models;
using DemoAPI1.Repositories;

namespace DemoAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = _repository.GetById(id);
            if (department != null)
                return Ok(department);
            else
                return NotFound($"Department with Id {id} not found");
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] Department department)
        {
            _repository.AddNewDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Department department)
        {
            _repository.UpdateDepartment(department);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_repository.GetById(id) == null)
                return NotFound($"Department with Id {id} not found");
            _repository.DeleteDepartment(id);
            return NoContent();
        }
    }
}
