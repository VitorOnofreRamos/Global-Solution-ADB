using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Repositories.Implementations;

public class MetricRepository : _Repository<Metric>, IMetricRepository
{
    public MetricRepository(ApplicationDbContext context) : base(context) { }
}
