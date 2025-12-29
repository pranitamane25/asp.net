using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopping.MVC.Models;

namespace Shopping.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

     public IActionResult Dashboard()
    {
        return View();
    }

    public JsonResult GetBarChartData()
    {
        var data = new
        {
            Labels = new[] { "Jan", "Feb", "Mar", "Apr" },
            Values = new[] { 12, 19, 3, 5 }
        };
 
        return Json(data);
    } 


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
