using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Global_Solution_ADB.Application.Services;

public class AlertService
{
    private readonly IAlertRepository _alertRepository;
    private readonly ISensorRepository _sensorRepository;

    public AlertService(IAlertRepository alertRepository, ISensorRepository sensorRepository)
    {
        _alertRepository = alertRepository;
        _sensorRepository = sensorRepository;
    }

    public async Task<LogAlert> GetAlertByIdAsync(int id) =>
        await _alertRepository.GetByIdAsync(id);

    public async Task<IEnumerable<LogAlert>> GetAllAlertAsync() =>
        await _alertRepository.GetAllAsync();

    public async Task AddAlertAsync(LogAlert logAlert) =>
        await _alertRepository.AddAsync(logAlert);

    public async Task UpdateAlertAsync(LogAlert logAlert) =>
        await _alertRepository.UpdateAsync(logAlert);

    public async Task RemoveAlertAsync(int id) =>
        await _alertRepository.RemoveAsync(id);

    //public async Task CheckAndGenerateAlertsAsync()
    //{
    //    const decimal thersholdMax = 100;

    //    var sensors = await _sensorRepository.GetAllAsync();
    //    foreach (var sensor in sensors)
    //    {
    //        var latestAnalysis = sensor.Analyses.OrderByDescending(a => a.Timestamp).FirstOrDefault();
    //        if (latestAnalysis != null && latestAnalysis.Value > thersholdMax)
    //        {
    //            await _alertRepository.AddAsync(new LogAlert
    //            {
    //                Description = $"Valor {latestAnalysis.Value} acima do limite!",
    //                TriggeredAt = DateTime.Now,
    //                IsResolved = false,
    //                AnalysisId = latestAnalysis.Id
    //            });
    //        }
    //    }
    //}

    public async Task<bool> ResolveAlertAsync(int id)
    {
        var alert = await _alertRepository.GetByIdAsync(id);
        if (alert == null || alert.IsResolved)
        {
            return false;
        }

        alert.IsResolved = true;
        alert.ResolvedAt = DateTime.Now;
        await _alertRepository.UpdateAsync(alert);
        return true;
    }

    public async Task<IEnumerable<LogAlert>> GetAlertsByNuclearPlantAsync(int nuclearPlantId)
    {
        var alerts = await _alertRepository.FindAsync(alert =>
            alert.Analysis.Sensor.NuclearPlantId == nuclearPlantId);

        return alerts ?? Enumerable.Empty<LogAlert>();
    }

    public async Task AddLogAlertWithProcedureAsync(LogAlert alert)
    {
        var parameters = new OracleParameter[]
        {
            new OracleParameter("p_AlertDescription", alert.Description),
            new OracleParameter("p_TriggeredAt", alert.TriggeredAt),
            new OracleParameter("p_ResolvedAt", alert.ResolvedAt ?? (object)DBNull.Value),
            new OracleParameter("p_IsResolved", alert.IsResolved ? "1" : "0"), // Converter boolean para CHAR(1)
            new OracleParameter("p_id_analysis", alert.AnalysisId)
        };

        await _alertRepository.InsertWithProcedureAsync("Insert_LogAlert", parameters);
    }
}
