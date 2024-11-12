using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_Metric")]
public class Metric : _BaseEntity
{    
    [Required]
    public DateTime NuclearPlantDate { get; set; } // Data em que as métricas foram registradas

    [Column(TypeName = "NUMBER(10, 2)")]
    public double ElectricityProvided { get; set; } // Quantidade de eletricidade gerada pela usina nuclear (em MW)

    [Range(0, 100)]
    [Column(TypeName = "NUMBER(5, 2)")]
    public double NuclearParticipation { get; set; } // Porcentagem da energia total gerada atribuída à energia nuclear

    [Range(0, 100)]
    [Column(TypeName = "NUMBER(5, 2)")]
    public double OperationalEfficiency { get; set; } // Eficiência operacional da usina, baseada em dados de performance

    [Required]
    [ForeignKey(nameof(NuclearPlant))]
    public int NuclearPlantId { get; set; } // ID da usina nuclear associada às métricas
    public NuclearPlant NuclearPlant { get; set; } // Referência à usina nuclear para a qual as métricas foram registradas
}
