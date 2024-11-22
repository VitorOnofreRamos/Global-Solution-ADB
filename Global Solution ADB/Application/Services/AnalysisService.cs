using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Global_Solution_ADB.Application.Services;

public class AnalysisService
{
    private readonly IAnalysisRepository _analysisRepository;

    public AnalysisService(IAnalysisRepository analysisRepository)
    {
        _analysisRepository = analysisRepository;
    }

    public async Task<Analysis> GetAnalysisByIdAsync(int id) =>
        await _analysisRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Analysis>> GetAllAnalysisAsync() =>
        await _analysisRepository.GetAllAsync();

    public async Task AddAnalysisAsync(Analysis analysis) =>
        await _analysisRepository.AddAsync(analysis);

    public async Task UpdateAnalysisAsync(Analysis analysis) =>
        await _analysisRepository.UpdateAsync(analysis);

    public async Task RemoveAnalysisAsync(int id) =>
        await _analysisRepository.RemoveAsync(id);



	public async Task<int> AddAnalysisWithProcedureAsync(Analysis analysis)
    {
        var parameters = new OracleParameter[]
         {
            new OracleParameter("p_AnalysisValue", analysis.Value),
            new OracleParameter("p_AnalysisTimestamp", analysis.Timestamp),
            new OracleParameter("p_id_sensor", analysis.SensorId)
         };

        return await _analysisRepository.InsertWithProcedureAsync("Insert_Analysis", parameters);
    }
}

