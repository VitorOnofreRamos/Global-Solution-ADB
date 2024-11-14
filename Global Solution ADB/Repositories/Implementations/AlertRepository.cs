using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Repositories.Implementations;

public class AlertRepository : _Repository<LogAlert>, IAlertRepository
{
    public AlertRepository(ApplicationDbContext context) : base(context) { }
}
