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
}