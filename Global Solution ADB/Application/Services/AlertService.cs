using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Application.Services;

public class AlertService
{
    private readonly IAlertRepository _alertRepository;

    public AlertService(IAlertRepository alertRepository)
    {
        _alertRepository = alertRepository;
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
}
