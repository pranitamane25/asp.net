using Microsoft.AspNetCore.Mvc;

namespace OrderProcessing.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateOrder()
    {
        return Ok("Order placed successfully");
    }
}