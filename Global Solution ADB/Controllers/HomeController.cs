using Global_Solution_ADB.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace Global_Solution_ADB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly string _connectionString;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("FiapOracleConnection");
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
    public IActionResult InsertTestData()
    {
        try
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                // Chamando cada procedure
                ExecuteProcedure(connection, "Insert_NuclearPlant", new OracleParameter[]
                {
                        new OracleParameter("p_plantName", "Usina Power On"),
                        new OracleParameter("p_fullCapacity", 300),
                        new OracleParameter("p_numberOfReactors", 2)
                });

                ExecuteProcedure(connection, "Insert_Metric", new OracleParameter[]
                {
                        new OracleParameter("p_MetricDate", DateTime.Now),
                        new OracleParameter("p_ElectricityProvided", 700),
                        new OracleParameter("p_NuclearParticipation", 50),
                        new OracleParameter("p_OperationalEfficiency", 80),
                        new OracleParameter("p_id_nuclearplant", 1)
                });

                ExecuteProcedure(connection, "Insert_Sensor", new OracleParameter[]
                {
                        new OracleParameter("p_SensorName", "Sensor de Temperatura do Reator"),
                        new OracleParameter("p_MachinaryLocation", "No maquinário do reator"),
                        new OracleParameter("p_Status", '1'), // '1' para ativo
                        new OracleParameter("p_id_nuclearplant", 1)
                });

                ExecuteProcedure(connection, "Insert_SensorType", new OracleParameter[]
                {
                        new OracleParameter("p_SpecificType", "Radiológico"),
                        new OracleParameter("p_id_sensor", 1)
                });

                ExecuteProcedure(connection, "Insert_Analysis", new OracleParameter[]
                {
                        new OracleParameter("p_AnalysisValue", 300),
                        new OracleParameter("p_AnalysisTimestamp", DateTime.Now),
                        new OracleParameter("p_id_sensor", 1)
                });

                ExecuteProcedure(connection, "Insert_LogAlert", new OracleParameter[]
                {
                        new OracleParameter("p_AlertDescription", "Sobreaquecimento no Reator"),
                        new OracleParameter("p_TriggeredAt", DateTime.Now),
                        new OracleParameter("p_ResolvedAt", null),
                        new OracleParameter("p_IsResolved", '0'), // '0' para não resolvido
                        new OracleParameter("p_id_analysis", 1)
                });
            }

            TempData["Message"] = "Dados de teste inseridos com sucesso!";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Erro ao inserir dados de teste: {ex.Message}";
        }

        return RedirectToAction("Index");
    }

    private void ExecuteProcedure(OracleConnection connection, string procedureName, OracleParameter[] parameters)
    {
        using (var command = new OracleCommand(procedureName, connection))
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();
        }
    }
}
