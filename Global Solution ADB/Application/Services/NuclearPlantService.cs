﻿using Global_Solution_ADB.Models.Entities;
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

    public async Task AddAppointmentAsync(NuclearPlant nuclearPlant) =>
        await _nuclearPlantRepository.AddAsync(nuclearPlant);

    public async Task UpdateAppointmentAsync(NuclearPlant nuclearPlant) =>
        await _nuclearPlantRepository.UpdateAsync(nuclearPlant);

    public async Task RemoveAppointmentAsync(int id) =>
        await _nuclearPlantRepository.RemoveAsync(id);
}
