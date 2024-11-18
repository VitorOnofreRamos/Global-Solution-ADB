using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Application.Services;

public class MetricService
{
    private readonly IMetricRepository _metricRepository;

    public MetricService(IMetricRepository metricRepository)
    {
        _metricRepository = metricRepository;
    }

    public async Task<Metric> GetMetricByIdAsync(int id) =>
        await _metricRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Metric>> GetAllMetricsAsync() =>
        await _metricRepository.GetAllAsync();

    public async Task AddMetricAsync(Metric metric) =>
        await _metricRepository.AddAsync(metric);

    public async Task UpdateMetricAsync(Metric metric) =>
        await _metricRepository.UpdateAsync(metric);

    public async Task RemoveMetricAsync(int id) =>
        await _metricRepository.RemoveAsync(id);
}
