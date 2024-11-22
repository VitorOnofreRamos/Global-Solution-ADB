using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Global_Solution_ADB.Application.Services;

public class AnalysisService
{
    private readonly IAnalysisRepository _analysisRepository;
    private readonly AlertService _alertService;

    public AnalysisService(IAnalysisRepository analysisRepository, AlertService alertService)
    {
        _analysisRepository = analysisRepository;
        _alertService = alertService;
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

    public async Task<int> GenerateAlertByAnalysis(int analysisId)
    {
		const decimal thresholdMax = 100;

		// Adicionar a análise ao banco de dados
		var analysis = await _analysisRepository.GetByIdAsync(analysisId);

		// Verificar o valor da análise e gerar um alerta, se necessário
		if (analysis.Value > thresholdMax)
		{
			//_logger.LogInformation($"Análise com valor acima do limite detectada. Gerando alerta para análise ID: {analysisId}");

            await _alertService.AddLogAlertWithProcedureAsync(new LogAlert
			{
				Description = $"Valor {analysis.Value} acima do limite!",
				TriggeredAt = DateTime.Now,
				IsResolved = false,
				AnalysisId = analysisId
			});

			//_logger.LogInformation($"Alerta gerado com sucesso para a análise ID: {analysisId}");
		}

		return analysisId;
	}

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

