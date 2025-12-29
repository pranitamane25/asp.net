using Microsoft.AspNetCore.Mvc;
using Shopping.MVC.Models;
using Shopping.MVC.Repositories.Interfaces;

namespace Shopping.MVC.Controllers;

public class ProductsController : Controller
{
    private readonly IProductsRepository _repository;

    public ProductsController(IProductsRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Items()
    {
        var items = _repository.GetAllProducts();
        // return View(items);
            return Json(items); // return JSON, not View

    }

    public IActionResult Details(int id)
    {
        var product = _repository.GetAllProducts()
                                 .FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        return View(product);
    }

   [HttpPost]
public IActionResult Create([FromBody] Product product)
{
//Console.WriteLine($"Product:,{product.Id} {product.Name}, {product.Price}");
    _repository.Insert(product);
    return Ok("Inserted");
    //return View(product);
}

    public IActionResult Remove(int productId)
    {
        var product = _repository.GetAllProducts()
                                 .FirstOrDefault(p => p.Id == productId);

        if (product != null)
            _repository.Remove(product);

        return RedirectToAction("Items");
        
    }
}
