using Global_Solution_ADB.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Global_Solution_ADB.Controllers;

[Route("Alert")]
public class AlertController : Controller
{
    private readonly AlertService _alertService;

    public AlertController(AlertService alertService)
    {
        _alertService = alertService; 
    }

    //GET: /Alert
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var alerts = await _alertService.GetAllAlertAsync();
        return View(alerts);
    }

    //GET /Alert/Details/{id}
    public async Task<IActionResult> Details(int id)
    {
        var alerts = await _alertService.GetAlertByIdAsync(id);
        if (alerts == null)
        {
            return NotFound();
        }

        return View(alerts);
    }

    //GET: /Alert/Delete/{id}
    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(int id) 
    {
        var alert = await _alertService.GetAlertByIdAsync(id);
        if (alert == null) 
        {
            return NotFound($"Alerta com ID {id} não encontrado.");
        }

        return RedirectToAction("Index");
    }

    //DELETE: /Alert/Delete/{id}
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _alertService.RemoveAlertAsync(id);
        return RedirectToAction("Index");
    }

    //PUT: /Alert/Resolve/{id}
    [HttpPost("Resolve/{id}")]
    public async Task<IActionResult> Resolve(int id)
    {
        var success = await _alertService.ResolveAlertAsync(id);
        if (success == null)
        {
            return NotFound($"Alerta com ID {id} não encontrado ou já resolvido.");
        }
        return RedirectToAction("Index");
    }
}
