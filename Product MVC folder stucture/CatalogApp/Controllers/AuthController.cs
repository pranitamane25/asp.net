using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using MyAssessment.WebMVC.Models;

namespace MVC.Controllers;

public class AuthController : Controller
{

    public AuthController()
    {
        
    }

    public IActionResult SignUp()
    {
        return View();
    }
    public IActionResult SignIn()
    {
        return View();
    }
}