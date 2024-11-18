using Global_Solution_ADB.Application.DTOs;
using Global_Solution_ADB.Application.Services;
using Global_Solution_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Global_Solution_ADB.Controllers;

[Route("NuclearPlant")]
public class NuclearPlantController : Controller
{
    private readonly NuclearPlantService _nuclearPlantService;

    public NuclearPlantController(NuclearPlantService nuclearPlantService)
    {
        _nuclearPlantService = nuclearPlantService;
    }

    //GET: /nuclearplants
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var nuclearplants = await _nuclearPlantService.GetAllNuclearPlantsAsync();

        var nuclearplantsDTOS = nuclearplants.Select(a => new NuclearPlantDTO
        {
            Id = a.Id,
            Name = a.Name,
            FullCapacity = a.FullCapacity,
            NumberOfReactors = a.NumberOfReactors
        }).ToList();

        return View(nuclearplantsDTOS);
    }

    //GET: /appointment/create
    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    //POST: appointment/create
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NuclearPlantDTO dto)
    {
        if (ModelState.IsValid)
        {
            var nuclearPlant = new NuclearPlant
            {
                Name = dto.Name,
                FullCapacity = dto.FullCapacity,
                NumberOfReactors= dto.NumberOfReactors
            };

            await _nuclearPlantService.AddNuclearPlantAsync(nuclearPlant);
            return RedirectToAction("Index");
        }

        foreach(var modelState in ModelState.Values)
        {
            foreach(var error in modelState.Errors)
            {
                Console.WriteLine($"Model Error: {error.ErrorMessage}");
            }
        }

        return View(dto);
    }

}
