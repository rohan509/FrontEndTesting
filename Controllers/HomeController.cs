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

    public IActionResult DahejList()
    {
        return View();
    }
    
    public IActionResult Para()
    {
        return View();
    }

    public IActionResult WeAre()
    {
        return View();
    }

    [HttpPost]
    public IActionResult WeAre(string answer1, string answer2, string answer3, string answer4, 
                               string answer5, string answer6, string answer7, string answer8,
                               string answer9, string answer10)
    {
        // Define correct answers
        Dictionary<string, string> correctAnswers = new()
        {
            { "answer1", "Wife on Leave" },
            { "answer2", "Gerbera Daisy" },
            { "answer3", "orchid" },
            { "answer4", "gym" },
            { "answer5", "Pragati" },
            { "answer6", "Shyambhavi" },
            { "answer7", "Infinite" },
            { "answer8", "Temple" },
            { "answer9", "Vomit" },
            { "answer10", "puchi" }
        };

        // Check answers
        Dictionary<string, string> userAnswers = new()
        {
            { "answer1", answer1 },
            { "answer2", answer2 },
            { "answer3", answer3 },
            { "answer4", answer4 },
            { "answer5", answer5 },
            { "answer6", answer6 },
            { "answer7", answer7 },
            { "answer8", answer8 },
            { "answer9", answer9 },
            { "answer10", answer10 }
        };

        int score = 0;
        foreach (var key in correctAnswers.Keys)
        {
            if (userAnswers[key] != null && ((userAnswers[key].Trim().Equals(correctAnswers[key], StringComparison.OrdinalIgnoreCase)) || userAnswers[key].Trim().ToLower()=="manu"))
            {
                score++;
            }
        }

        ViewBag.Score = score;
        ViewBag.TotalScore = score;
        return View();
    }

    public IActionResult Moments()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Moments(string category)
    {
        if (!string.IsNullOrEmpty(category) && category.Trim().Equals("8303025419", StringComparison.OrdinalIgnoreCase))
        {
            ViewBag.ShowPhotos = true;
        }
        else if (!string.IsNullOrEmpty(category))
        {
            ViewBag.ShowError = true;
        }
        return View();
    }


   
}
