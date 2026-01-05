using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Product()
    {
        return Ok("Products placed successfully");
    }
}