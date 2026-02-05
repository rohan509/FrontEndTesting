using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MydeploymentProject.Models;

namespace MydeploymentProject.Controllers;

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

    public IActionResult NoFirst()
    {
        return View();
    }

    public IActionResult NoSecond()
    {
        return View();
    }

    public IActionResult NoThird()
    {
        return View();
    }

    public IActionResult Yes()
    {
        return View();
    }
    

   
}
