using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;

namespace Global_Solution_ADB.Repositories.Implementations;

public class AnalysisRepository : _Repository<Analysis>, IAnalysisRepository
{
    public AnalysisRepository(ApplicationDbContext context) : base(context) { }
}
