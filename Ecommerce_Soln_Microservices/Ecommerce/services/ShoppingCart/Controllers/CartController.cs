using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    [HttpPost]
    public IActionResult Cart()
    {
        return Ok("Order placed successfully");
    }
}