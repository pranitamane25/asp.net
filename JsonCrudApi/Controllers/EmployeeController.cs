using jsoncrudapi.Models;
using jsoncrudapi.Services;
using Microsoft.AspNetCore.Mvc;
namespace jsoncrudapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController:ControllerBase
{
    private readonly IEmployeeService _service;
    public EmployeeController(IEmployeeService service)
    {
        _service=service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
            Employee employee=_service.GetById(id);

            if (employee == null)
                return NotFound();

                return Ok(employee);
            }
        

        [HttpPost]

        public IActionResult Add(Employee employee)
    {
        _service.Add(employee);
        return Ok("Employee Added successfully");
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok("Employee Deleted successfully");
    }
}
