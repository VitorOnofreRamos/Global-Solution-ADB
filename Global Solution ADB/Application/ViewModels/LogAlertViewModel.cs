using Global_Solution_ADB.Models.Entities;

namespace Global_Solution_ADB.Application.ViewModels;

public class LogAlertViewModel
{
    public int AlertId { get; set; }
    public string Descrtiption { get; set; }
    public DateTime TriggeredAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public bool IsResolved { get; set; }

    //Relacionamento com Analysis
    public AnalysisViewModel Analysis { get; set; }

    //Relacionamento com Sensor (via Analysis)
    public SensorViewModel Sensor { get; set; }

    //Relacionamento com Usina (via Sensor)
    public NuclearPlantViewModel NuclearPlant { get; set; }
}