using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnimesFavoritos.Models;
using AnimesFavoritos.Services;

namespace AnimesFavoritos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAnimesService _animeservice;

    public HomeController(ILogger<HomeController> logger, IAnimesService animeService)
    {
        _logger = logger;
        _animeservice = animeService;
    }

    public IActionResult Index(string Genero)
    {
        var genero = _animeservice.GetAnimesDto();
        ViewData["filter"] = string.IsNullOrEmpty(Genero) ? "all" : Genero;
        return View(Genero);
    }

    public IActionResult Details(int numero)
    {
        var animes = _animeservice.GetDetailedAnimes(numero: numero);
        return View(animes);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
      ?? HttpContext.TraceIdentifier });
    }
}
