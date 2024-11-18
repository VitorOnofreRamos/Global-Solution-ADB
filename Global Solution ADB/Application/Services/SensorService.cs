using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Application.Services;

public class SensorService
{
    private readonly ISensorRepository _sensorRepository;

    public SensorService(ISensorRepository sensorRepository)
    {
        _sensorRepository = sensorRepository;
    }

    public async Task<Sensor> GetSensorByIdAsync(int id) =>
        await _sensorRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Sensor>> GetAllSensorAsync() =>
        await _sensorRepository.GetAllAsync();

    public async Task AddSensorAsync(Sensor sensorRepository) =>
        await _sensorRepository.AddAsync(sensorRepository);

    public async Task UpdateSensorAsync(Sensor sensorRepository) =>
        await _sensorRepository.UpdateAsync(sensorRepository);

    public async Task RemoveSensorAsync(int id) =>
        await _sensorRepository.RemoveAsync(id);
}
