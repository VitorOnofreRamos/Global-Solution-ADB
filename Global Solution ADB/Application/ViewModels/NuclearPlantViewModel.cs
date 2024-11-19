using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.ViewModels;

public class NuclearPlantViewModel
{
    //NuclearPlant Info
    public int NuclearPlantId { get; set; }
    public string NuclearPlantName { get; set; }
    public decimal FullCapacity { get; set; }
    public int NumberOfReactors { get; set; }
    public List<SensorViewModel> Sensors { get; set; } = new List<SensorViewModel>();
    public List<MetricViewModel> Metrics { get; set; } = new List<MetricViewModel>();
}
public class SensorViewModel
{
    public int SensorId { get; set; }
    public string SensorName { get; set; }
    public string MachinaryLocation { get; set; }
    public bool Status { get; set; }
}
public class MetricViewModel
{
    public int MetricId { get; set; }
    public DateTime MetricDate { get; set; }
    public decimal ElectricityProvided { get; set; }
    public decimal NuclearParticipation { get; set; }
    public decimal OperationalEfficiency { get; set; }
}
