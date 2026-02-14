using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Higby.Models;

namespace Mission06_Higby.Controllers;

public class HomeController : Controller
{
    private readonly MovieCollectionContext _movieCollectionContext;

    public HomeController(MovieCollectionContext movieCollectionContext)
    {
        _movieCollectionContext = movieCollectionContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieCollection()
    {
        return View(new Movie());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult MovieCollection(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        _movieCollectionContext.Movies.Add(movie);
        _movieCollectionContext.SaveChanges();

        return View("Confirmation", movie);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
