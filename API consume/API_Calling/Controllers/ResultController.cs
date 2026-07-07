using Microsoft.AspNetCore.Mvc;
namespace API_Calling.Controllers{


[ApiController]
[Route("api/[controller]")]
public class ResultController : ControllerBase
{
    public readonly IResultService _resultService;

    public ResultController(IResultService resultService)
    {
        _resultService = resultService;
    }
       [HttpGet("results")]
    public async Task<IActionResult> GetAllResults()
    {
        var results = await _resultService.GetAllResults();

        if (results == null || !results.Any())
        {
            return NotFound("No results found");
        }

        return Ok(results);
    }
}
}
