using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Implementations;
using Global_Solution_ADB.Repositories.Interfaces;

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

    public async Task CheckAndGenerateAlertsAsync()
    {
        const decimal thersholdMax = 100;

        var sensors = await _sensorRepository.GetAllAsync();
        foreach (var sensor in sensors)
        {
            var latestAnalysis = sensor.Analyses.OrderByDescending(a => a.Timestamp).FirstOrDefault();
            if (latestAnalysis != null && latestAnalysis.Value > thersholdMax)
            {
                await _alertRepository.AddAsync(new LogAlert
                {
                    Description = $"Valor {latestAnalysis.Value} acima do limite!",
                    TriggeredAt = DateTime.Now,
                    IsResolved = false,
                    AnalysisId = latestAnalysis.Id
                });
            }
        }
    }

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
}
