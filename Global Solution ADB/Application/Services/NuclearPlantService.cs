using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;

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

    public async Task<NuclearPlant> GetNuclearPlantWithDetailsAsync(int id)
    {
        return await _nuclearPlantRepository.GetByIdWithRelationsAsync(
            id,
            np => np.Sensors,
            np => np.Metrics
        );
    }

    public async Task<int> AddNuclearPlantWithProcedureAsync(NuclearPlant nuclearPlant)
    {
        var parameters = new OracleParameter[]
        {
            new OracleParameter("p_plantName", nuclearPlant.Name),
            new OracleParameter("p_fullCapacity", nuclearPlant.FullCapacity),
            new OracleParameter("p_numberOfReactors", nuclearPlant.NumberOfReactors)
        };

        return await _nuclearPlantRepository.InsertWithProcedureAsync("Insert_NuclearPlant", parameters);
    }
}
