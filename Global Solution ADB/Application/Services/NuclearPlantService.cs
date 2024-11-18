using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;
using System.Linq.Expressions;

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

    public async Task<IEnumerable<NuclearPlant>> SearchNuclearPlantAsync(string name, string fullCapacity, string numberOfReactors)
    {
        // Carregar todas as usinas nucleares do banco de dados
        var nuclearPlants = await _nuclearPlantRepository.GetAllAsync();

        // Aplicar filtros dinamicamente
        if (!string.IsNullOrEmpty(name))
        {
            nuclearPlants = nuclearPlants.Where(np => np.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(fullCapacity) && decimal.TryParse(fullCapacity, out decimal capacity))
        {
            nuclearPlants = nuclearPlants.Where(np => np.FullCapacity == capacity).ToList();
        }

        if (!string.IsNullOrEmpty(numberOfReactors) && int.TryParse(numberOfReactors, out int reactors))
        {
            nuclearPlants = nuclearPlants.Where(np => np.NumberOfReactors == reactors).ToList();
        }

        return nuclearPlants;
    }
}
