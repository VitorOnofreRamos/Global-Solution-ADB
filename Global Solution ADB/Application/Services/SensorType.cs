using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Application.Services;

public class SensorTypeService
{
    private readonly ISensorTypeRepository _sensorTypeRepository;

    public SensorTypeService(ISensorTypeRepository sensorTypeRepository)
    {
        _sensorTypeRepository = sensorTypeRepository;
    }

    public async Task<SensorType> GetSensorTypeByIdAsync(int id) =>
        await _sensorTypeRepository.GetByIdAsync(id);

    public async Task<IEnumerable<SensorType>> GetAllSensorTypeAsync() =>
        await _sensorTypeRepository.GetAllAsync();

    public async Task AddSensorTypeAsync(SensorType sensorType) =>
        await _sensorTypeRepository.AddAsync(sensorType);

    public async Task UpdateSensorTypeAsync(SensorType sensorType) =>
        await _sensorTypeRepository.UpdateAsync(sensorType);

    public async Task RemoveSensorTypeAsync(int id) =>
        await _sensorTypeRepository.RemoveAsync(id);
}
