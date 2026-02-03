using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCapp.DAL.Store;
using MVCapp.PL.Models;

namespace MVCapp.PL.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _dbContext;

    public HomeController(AppDbContext dbContext, ILogger<HomeController> logger)
    {
        _logger = logger;
        _dbContext = dbContext;

    }

    public IActionResult Index()
    {
        var products = _dbContext.Users.ToList();
        Console.WriteLine(products);
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
