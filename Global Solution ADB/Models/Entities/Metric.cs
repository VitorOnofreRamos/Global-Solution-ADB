using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_Metric")]
public class Metric
{
    [Required]
    [ForeignKey(nameof(NuclearPlant))]
    public int NuclearPlantId { get; set; }
    public NuclearPlant NuclearPlant { get; set; }
    [Required]
    public DateTime NuclearPlantDate { get; set; }
    public double ElectricityProvided { get; set; }
    public double NuclearParticipation { get; set; }
    public double OperationalEfficiency { get; set; }
}
