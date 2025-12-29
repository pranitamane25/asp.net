using Microsoft.AspNetCore.Mvc;
using Shopping.MVC.Models;

using Shopping.MVC.Repositories.Interfaces;

namespace Shopping.MVC.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartRepository _repository;

    public ShoppingCartController(IShoppingCartRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {
       List<Item> items = _repository.GetItems();
       return View(items);
    }

    public IActionResult Add(int id)
    {
        _repository.AddToCart(id);
        return RedirectToAction("Index");
    }

    public IActionResult Summary()
    {
       List<Item> items = _repository.GetItems();
        return View(items);
    }
}
