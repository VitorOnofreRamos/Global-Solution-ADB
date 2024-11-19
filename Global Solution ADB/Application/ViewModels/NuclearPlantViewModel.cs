using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.ViewModels;

public class NuclearPlantViewModel
{
    //NuclearPlant Info
    public int NuclearPlantId { get; set; }
    public string NuclearPlantName { get; set; }
    public decimal FullCapacity { get; set; }
    public int NumberOfReactors { get; set; }

    //Metric Info
    public int MetricId { get; set; }
    public DateTime MetricDate { get; set; }
    public decimal ElectricityProvided { get; set; }
    public decimal NuclearParticipation { get; set; }
    public decimal OperationalEfficiency { get; set; }
}
