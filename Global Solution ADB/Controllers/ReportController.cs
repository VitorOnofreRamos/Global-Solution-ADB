using Microsoft.AspNetCore.Mvc;

namespace Global_Solution_ADB.Controllers;

public class ReportController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
