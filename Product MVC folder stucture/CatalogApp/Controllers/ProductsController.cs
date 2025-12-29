using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using  CatalogApp.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;
using System.Data.Common;

namespace MVC.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new Product { Id = 34, Title = "laptop",Price=1000,Quantity=1,Description="portable" },
            new Product { Id = 35, Title = "mobile", Price=2000,Quantity=2,Description="portable" },
            new Product { Id = 36, Title = "computer",Price=3000,Quantity=3,Description="small"  }
        };
        return Json(products);
       //return View();
    }

  public IActionResult Details(int id)
    {
       var products = new List<Product>
       {
           new Product{ Id = 10, Title = "apple",Price=1000,Quantity=1,Description="portable"},
            new Product {Id = 20, Title = "pineapple",Price=1000,Quantity=1,Description="portable"}
       };
         // Find product by id
    var product = products.FirstOrDefault(p => p.Id == id);

    if (product == null)
    {
        return NotFound("Product not found");
    }
       return Json(product);

        //return View();
    }

    public IActionResult Create(Product product)
    {
        var products=new List<Product>
        {
        new Product { Id = 50, Title = "Table", Price = 3000, Quantity = 1, Description = "wooden" },
        new Product { Id = 51, Title = "Chair", Price = 1500, Quantity = 4, Description = "plastic" },
        new Product { Id = 52, Title = "Fan", Price = 2000, Quantity = 2, Description = "electric" }
        };
         // Add new product that comes from form
    product.Id = 101;  
    products.Add(product);

    // Return combined list as JSON
    //return Json(products);
        return View();
    }
    
}
