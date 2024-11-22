using Global_Solution_ADB.Application.Services;
using Global_Solution_ADB.Models;
using Global_Solution_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace Global_Solution_ADB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly string _connectionString;
    private readonly NuclearPlantService _nuclearPlantService;
    private readonly MetricService _metricService;
    private readonly SensorService _sensorService;
    private readonly SensorTypeService _sensorTypeService;
    private readonly AnalysisService _analysisService;
    private readonly AlertService _alertService;

    public HomeController(
        ILogger<HomeController> logger, 
        IConfiguration configuration,
        NuclearPlantService nuclearPlantService,
        MetricService metricService,
        SensorService sensorService,
        SensorTypeService sensorTypeService,
        AnalysisService analysisService,
        AlertService alertService)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("FiapOracleConnection");
        _nuclearPlantService = nuclearPlantService;
        _metricService = metricService;
        _sensorService = sensorService;
        _sensorTypeService = sensorTypeService;
        _analysisService = analysisService;
        _alertService = alertService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> InsertTestData()
    {
        try
        {
            //Inserir Usina
            var nuclearPlantId = await _nuclearPlantService.AddNuclearPlantWithProcedureAsync(new NuclearPlant
            {
                Name = "Usina Power On",
                FullCapacity = 300,
                NumberOfReactors = 2
            });
            _logger.LogInformation($"Usina inserida");

            // Inserir Métrica
            await _metricService.AddMetricWithProcedureAsync(new Metric
            {
                MetricDate = DateTime.Now,
                ElectricityProvided = 700,
                NuclearParticipation = 50,
                OperationalEfficiency = 80,
                NuclearPlantId = nuclearPlantId
            });
            _logger.LogInformation($"Métrica inserida");

            // Inserir Sensor
            var sensorId = await _sensorService.AddSensorWithProcedureAsync(new Sensor
            {
                Name = "Sensor de Temperatura do Reator",
                MachinaryLocation = "No maquinário do reator",
                Status = true,
                NuclearPlantId = nuclearPlantId
            });
            _logger.LogInformation($"Sensor inserido");

            // Inserir Tipo de Sensor
            await _sensorTypeService.AddSensorTypeWithProcedureAsync(new SensorType
            {
                SpecificType = "Radiológico",
                SensorId = sensorId
            });
            _logger.LogInformation($"Tipo de Sensor inserido");

            // Inserir Análise
            var analysisId = await _analysisService.AddAnalysisWithProcedureAsync(new Analysis
            {
                Value = 300,
                Timestamp = DateTime.Now,
                SensorId = sensorId
            });
            _logger.LogInformation($"Análise inserida");

            await _analysisService.GenerateAlertByAnalysis(analysisId);

            TempData["Message"] = "Dados de teste inseridos com sucesso!";
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro ao inserir dados de teste: {ex.Message}");
            TempData["Error"] = $"Erro ao inserir dados de teste: {ex.Message}";
        }

        return RedirectToAction("Index");
    }
}
