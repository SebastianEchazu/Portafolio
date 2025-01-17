﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos _repositorioProyectos;
    private readonly IServicioEmail _servicioEmail;

    public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos,
     IServicioEmail servicioEmail)
    {
        _logger = logger;
        _repositorioProyectos = repositorioProyectos;
        _servicioEmail = servicioEmail;
    }
  
    public IActionResult Index()
    {

        var proyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();

        var modelo = new HomeIndexViewModel() { Proyectos = proyectos };

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
    public async Task<IActionResult> Contacto(ContactoViewModel modelo)
    {
        await _servicioEmail.EnviarEmail(modelo);
        if (ModelState.IsValid)
        {
            // Enviar correo electrónico aquí.
            return RedirectToAction("Gracias");
        }

        return View(modelo);
    }

    public IActionResult Gracias()

    {
        return View();
     }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
