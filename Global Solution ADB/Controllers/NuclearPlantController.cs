using Global_Solution_ADB.Application.DTOs;
using Global_Solution_ADB.Application.Services;
using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Global_Solution_ADB.Controllers;

[Route("NuclearPlant")]
public class NuclearPlantController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly NuclearPlantService _nuclearPlantService;

    public NuclearPlantController(IUnitOfWork unitOfWork, NuclearPlantService nuclearPlantService)
    {
        _unitOfWork = unitOfWork;
        _nuclearPlantService = nuclearPlantService;
    }

    //GET: /nuclearplant
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

    //GET: /Nuclearplant/Details/{id}
    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var nuclearplant = await _nuclearPlantService.GetNuclearPlantByIdAsync(id);
        if (nuclearplant == null)
        {
            return NotFound($"Usina com ID {id} não encontrada.");
        }

        var viewModel = new NuclearPlantViewModel
        {
            NuclearPlantId = nuclearplant.Id,
            NuclearPlantName = nuclearplant.Name,
            FullCapacity = nuclearplant.FullCapacity,
            NumberOfReactors = nuclearplant.NumberOfReactors,
        };

        return View(viewModel);
    }

	//GET: /nuclearplantst/create
	[HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    //POST: nuclearplant/create
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

    //GET: /nuclearplant/delete/{id}
    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var nuclearplant = await _nuclearPlantService.GetNuclearPlantByIdAsync(id);
        if (nuclearplant == null)
        {
            return NotFound($"Usina com ID {id} não encontrada.");
        }

        var dto = new NuclearPlantDTO
        {
            Id = nuclearplant.Id,
            Name = nuclearplant.Name,
            FullCapacity = nuclearplant.FullCapacity,
            NumberOfReactors = nuclearplant.NumberOfReactors
        };

        return View(dto);
    }

    //DELETE: /nuclearplant/delete/{id}
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _nuclearPlantService.RemoveNuclearPlantAsync(id);
        return RedirectToAction("Index", "NuclearPlant");
    }

    //GET: /nuclearplant/edit/{id}
    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var nuclearplant = await _nuclearPlantService.GetNuclearPlantByIdAsync(id);
        if (nuclearplant == null)
        {
            return NotFound();
        }

        var dto = new NuclearPlantDTO
        {
            Id = nuclearplant.Id,
            Name = nuclearplant.Name,
            FullCapacity = nuclearplant.FullCapacity,
            NumberOfReactors = nuclearplant.NumberOfReactors
        };

        return View(dto);
    }


    //PUT: /nuclearplant/edit/{id}
    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, NuclearPlantDTO dto)
    {
        if(id != dto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid) 
        {
            var nuclearplant = await _nuclearPlantService.GetNuclearPlantByIdAsync(id);
            if (nuclearplant == null) 
            {
                return NotFound();
            }

            nuclearplant.Name = dto.Name;
            nuclearplant.FullCapacity = dto.FullCapacity;
            nuclearplant.NumberOfReactors = dto.NumberOfReactors;

            await _nuclearPlantService.UpdateNuclearPlantAsync(nuclearplant);

            return RedirectToAction("Index");
        }

        return View(dto);
    }
}
