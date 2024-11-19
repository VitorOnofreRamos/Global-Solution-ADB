using Global_Solution_ADB.Application.ViewModels;
using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Application.Services;

public class NuclearPlantService
{
    private readonly INuclearPlantRepository _nuclearPlantRepository;

    public NuclearPlantService(INuclearPlantRepository nuclearPlantRepository)
    {
        _nuclearPlantRepository = nuclearPlantRepository;
    }

    public async Task<NuclearPlant> GetNuclearPlantByIdAsync(int id) =>
        await _nuclearPlantRepository.GetByIdAsync(id);

    public async Task<IEnumerable<NuclearPlant>> GetAllNuclearPlantsAsync() =>
        await _nuclearPlantRepository.GetAllAsync();

    public async Task AddNuclearPlantAsync(NuclearPlant nuclearPlant) =>
        await _nuclearPlantRepository.AddAsync(nuclearPlant);

    public async Task UpdateNuclearPlantAsync(NuclearPlant nuclearPlant) =>
        await _nuclearPlantRepository.UpdateAsync(nuclearPlant);

    public async Task RemoveNuclearPlantAsync(int id) =>
        await _nuclearPlantRepository.RemoveAsync(id);

    public async Task<MonitoringViewModel> GetMonitoringDataAsync(int nuclearPlantId) 
    {
        var nuclearPlant = await _nuclearPlantRepository.FindAsync(np => np.Id == nuclearPlantId);

        var plant = nuclearPlant.FirstOrDefault();
        if (plant == null)
        {
            return null;
        }

        var sensors = plant.Sensors.Select(sensor => new SensorViewModel
        {
            Name = sensor.Name,
            MachinaryLocation = sensor.MachinaryLocation,
            CurrentValue = sensor.Analyses.OrderByDescending(a => a.Timestamp).FirstOrDefault()?.Value,
            Status = sensor.Status,
        });

        return new MonitoringViewModel 
        {
            NuclearPlantName = plant.Name,
            Sensors = sensors,
        };
    }
}
