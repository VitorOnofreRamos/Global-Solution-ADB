using Global_Solution_ADB.Models.Entities;

namespace Global_Solution_ADB.Application.ViewModels;

public class AlertViewModel
{
    //Alert Info
    public int AlertId { get; set; }
    public string Descrtiption { get; set; }
    public DateTime TriggeredAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public bool IsResolved { get; set; }

    //Analysis Info
    public int AnalysisId { get; set; }
    public decimal AnalysisValue { get; set; }
    public DateTime AnalysisTimestamp { get; set; }

    //Sensor Info
    public int SensorId { get; set; }
    public string SensorName { get; set; }
    public string SensorType { get; set; } //---
    public string MachinaryLocation { get; set; }
    public bool Status { get; set; }

    //Usina Info
    public int UsinaId { get; set; }
    public string UsinaName { get; set; }
}
