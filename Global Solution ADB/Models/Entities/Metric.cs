using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("METRIC")]
public class Metric : _BaseEntity
{
    [Column("METRICDATE")]
    [Required]
    public DateTime MetricDate { get; set; } = DateTime.Now;

    [Column("ELECTRICITYPROVIDED", TypeName = "NUMBER")]
    [Required]
    public decimal ElectricityProvided { get; set; }

    [Column("NUCLEARPARTICIPATION", TypeName = "NUMBER")]
    [Required]
    public decimal NuclearParticipation { get; set; }

    [Column("OPERATIONALEFFICIENCY", TypeName = "NUMBER")]
    [Required]
    public decimal OperationalEfficiency { get; set; }

    [Column("ID_NUCLEARPLANT")]
    [Required]
    [ForeignKey(nameof(NuclearPlant))]
    public int NuclearPlantId { get; set; }
    public virtual NuclearPlant NuclearPlant { get; set; }
}
