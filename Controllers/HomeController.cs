using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos _repositorioProyectos;

    public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
    {
        _logger = logger;
        _repositorioProyectos = repositorioProyectos;
      
    }
    public IActionResult Index()
    {
    
        var proyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();

        var modelo = new HomeIndexViewModel() { Proyectos = proyectos};

        return View(modelo);
    }


    public IActionResult Proyectos()
    {
        var proyectos = _repositorioProyectos.ObtenerProyectos();

        return View(proyectos);
    }

    [HttpGet]
    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contacto(ContactoViewModel modelo)
    {
        if (ModelState.IsValid)
        {
            // Enviar correo electrónico aquí.
            return RedirectToAction("Index");
        }

        return View(modelo);
    } 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
