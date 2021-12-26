using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos _repositorioProyectos;
    private readonly ServicioUnico _servicioUnico;
    private readonly ServicioDelimitado _servicioDelimitado;
    private readonly ServicioTransitorio _servicioTransitorio;

    public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos,
     ServicioUnico servicioUnico,
     ServicioDelimitado servicioDelimitado,
     ServicioTransitorio servicioTransitorio)
    {
        _logger = logger;
        _repositorioProyectos = repositorioProyectos;
        _servicioUnico = servicioUnico;
        _servicioDelimitado = servicioDelimitado;
        _servicioTransitorio = servicioTransitorio;

    }


    public IActionResult Index()
    {

        var guidNewModel = new EjemploGuidViewModel
        {
            transitorio = _servicioTransitorio.ObtenerGuid,
            Delimitado = _servicioDelimitado.ObtenerGuid,
            Unico = _servicioUnico.ObtenerGuid
        };

        var proyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();

        var modelo = new HomeIndexViewModel() { Proyectos = proyectos, EjemploGuid_1 = guidNewModel };

        return View(modelo);
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
