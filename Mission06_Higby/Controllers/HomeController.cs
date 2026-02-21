using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Higby.Models;

namespace Mission06_Higby.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;
    
    public HomeController(MovieCollectionContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    public IActionResult MovieCollection()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult MovieCollection(Movie response)
    {
        _context.Movies.Add(response); //adds record to the database
        _context.SaveChanges();

        return View("Confirmation", response);
    }

    public IActionResult MovieView()
    {
        // linq language in dotnet
        var movies = _context.Movies
            .OrderBy(x => x.Title).ToList();
        
        return View(movies);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}