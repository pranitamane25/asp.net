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
        ViewBag.totalproducts=items.Count;

        ViewData["title"]="product list";
        ViewData["offer"]="Flat 20% OFF";
        
            return View(items); // return  View

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
public IActionResult Create( Product product)
{

    _repository.Insert(product);
    TempData["Success"]="Product added successfully";
    return RedirectToAction ("items");
}

[HttpGet]
public IActionResult Create()
{
    return View();
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
