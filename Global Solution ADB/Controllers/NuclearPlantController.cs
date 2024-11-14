using Global_Solution_ADB.Application.DTOs;
using Global_Solution_ADB.Application.Services;
using Microsoft.AspNetCore.Mvc;

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
}
