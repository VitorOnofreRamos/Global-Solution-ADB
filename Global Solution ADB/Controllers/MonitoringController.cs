using Global_Solution_ADB.Application.Services;
using Global_Solution_ADB.Infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution_ADB.Controllers;

[Route("Monitoring")]
public class MonitoringController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly NuclearPlantService _nuclearPlantService;

    public MonitoringController(IUnitOfWork unitOfWork, NuclearPlantService nuclearPlantService)
    {
        _unitOfWork = unitOfWork;
        _nuclearPlantService = nuclearPlantService;
    }

    [HttpGet("{nuclearPlantId}")]
    public async Task<IActionResult> Index(int nuclearPlantId)
    {
        var monitoringData = await _nuclearPlantService.GetMonitoringDataAsync(nuclearPlantId);

        if (monitoringData == null) 
        {
            return NotFound($"Usina com ID {nuclearPlantId} não encontrada.");
        }

        return View(monitoringData);
    }
}
