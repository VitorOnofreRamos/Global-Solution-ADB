using Global_Solution_ADB.Application.DTOs;
using Global_Solution_ADB.Application.Services;
using Global_Solution_ADB.Application.ViewModels;
using Global_Solution_ADB.Infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution_ADB.Controllers;

[Route("Alert")]
public class AlertController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AlertService _alertService;

    public AlertController(IUnitOfWork unitOfwork, AlertService alertService)
    {
        _unitOfWork = unitOfwork;
        _alertService = alertService; 
    }

    //GET: /Alert
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var alerts = await _alertService.GetAllAlertAsync();

        var alertDTOS = alerts.Select(a => new LogAlertDTO
        {
            Id = a.Id,
            AnalysisId = a.AnalysisId,
            TriggeredAt = a.TriggeredAt,
            IsResolved = a.IsResolved,
        }).ToList();

        return View(alertDTOS);
    }

    //GET:  /Alert/ByNuclearPlant/{nuclearPlantId}
    [HttpGet("ByNuclearPlant/{nuclearPlantId}")]
    public async Task<IActionResult> AlertsByNuclearPlant(int nuclearPlantId)
    {
        var alerts = await _alertService.GetAlertsByNuclearPlantAsync(nuclearPlantId);
        if (alerts == null || !alerts.Any())
        {
            return NotFound($"Nenhum alerta encontrado para a Usina com ID {nuclearPlantId}.");
        }

        var alertDTOS = alerts.Select(a => new LogAlertDTO
        {
            Id = a.Id,
            AnalysisId = a.AnalysisId,
            TriggeredAt = a.TriggeredAt,
            IsResolved = a.IsResolved,
        }).ToList();

        return View("Index", alertDTOS); // Reutiliza a View Index para exibir os alertas
    }

    //GET /Alert/Details/{id}
    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var alert = await _alertService.GetAlertByIdAsync(id);
        if (alert == null)
        {
            return NotFound($"Alerta com ID {id} não encontrada.");
        }

        var viewModel = new LogAlertViewModel
        {
            AlertId = alert.Id,
            Descrtiption = alert.Description,
            TriggeredAt = alert.TriggeredAt,
            ResolvedAt = alert.ResolvedAt,
            IsResolved = alert.IsResolved
        };

        return View(viewModel);
    }

    //GET: /Alert/ToJson/{id}
    [HttpGet("ToJson/{id}")]
    public async Task<IActionResult> ToJson(int id)
    {
        var alertJson = await _alertService.GetLogAlertJsonAsync(id);

        if (string.IsNullOrEmpty(alertJson))
        {
            return NotFound($"Alerta com ID {id} não encomtrada.");
        }

        ViewData["LogAlertJson"] = alertJson;

        return View();
    }

    //DELETE: /Alert/Delete/{id}
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var alert = await _alertService.GetAlertByIdAsync(id);
        if(alert == null)
        {
            return NotFound($"Alerta com ID {id} não encontrado.");
        }

        await _alertService.RemoveAlertAsync(id);
        return Ok(new {message = "Alerta excluído com sucesso!"});
    }

    //PUT: /Alert/Resolve/{id}
    [HttpPost("Resolve/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Resolve(int id)
    {
        var success = await _alertService.ResolveAlertAsync(id);
        if (!success)
        {
            return NotFound($"Alerta com ID {id} não encontrado ou já resolvido.");
        }
        return RedirectToAction("Index");
    }
}
