using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.ViewModels;

public class NuclearPlantViewModel
{
    public int NuclearPlantId { get; set; }
    public string NuclearPlantName { get; set; }
    public decimal FullCapacity { get; set; }
    public int NumberOfReactors { get; set; }
    public List<SensorViewModel> Sensors { get; set; } = new List<SensorViewModel>();
    public List<MetricViewModel> Metrics { get; set; } = new List<MetricViewModel>();
}
