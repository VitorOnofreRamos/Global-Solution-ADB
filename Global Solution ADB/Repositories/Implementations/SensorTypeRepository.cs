using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Repositories.Interfaces;
using Global_Solution_ADB.Models.Entities;

namespace Global_Solution_ADB.Repositories.Implementations;

public class SensorTypeRepository : _Repository<SensorType>, ISensorTypeRepository
{
    public SensorTypeRepository(ApplicationDbContext context) : base(context) { }
}
