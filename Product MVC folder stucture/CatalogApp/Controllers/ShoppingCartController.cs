using Microsoft.AspNetCore.Mvc;
using CatalogApp.Models;
using System.Collections.Generic;
using System.Linq;


namespace MVC.Controllers;
public class ShoppingCartController : Controller
{
       private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Title = "Laptop", Price = 50000 },
            new Product { Id = 2, Title = "Mobile", Price = 20000 },
            new Product { Id = 3, Title = "Headphones", Price = 1500 }
        };

        public static List<Product>cart=new List<Product>();

    public IActionResult Index()
    {
   
   
    //return Json(products);
        return View(products);
    }

    public IActionResult Add(int id)
    {
           // find product by id
            var product = products.FirstOrDefault(p => p.Id == id);

             if (product == null)
    {
        return NotFound("Product not found");
    }
       // add to cart
        cart.Add(product);

             // return only that single product data
            return Json(product);
        }

    public IActionResult Summary()
    {
        return View(cart);
    }
    };