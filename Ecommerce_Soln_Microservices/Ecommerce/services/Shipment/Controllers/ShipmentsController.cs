using Microsoft.AspNetCore.Mvc;

namespace Shipment.Controllers;

[ApiController]
[Route("api/shipment")]
public class ShipmentsController : ControllerBase
{
    [HttpPost]
    public IActionResult Ship()
    {
        
        return Ok("Shipment created");
    }
}
