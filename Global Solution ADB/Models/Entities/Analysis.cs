using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_Analysis")]
public class Analysis : _BaseEntity
{
    [Required]
    public double Value {  get; set; } // Valor medido pelo sensor(ex.: temperatura, radiação)
    
   
    
    [Required]
    public DateTime Timestamp { get; set; } // Data e hora em que a medição foi realizada

    [Required]
    [ForeignKey(nameof(Sensor))]
    public int SensorId { get; set; } // ID do sensor que registrou a medição
    public Sensor Sensor { get; set; } // Referência ao sensor associado à análise
}
