using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

public class Analysis : _BaseEntity
{
    [Required]
    public double Value {  get; set; } //Value mesaured by the sensor
    [Required]
    public EnumAnalysisUnit Unit { get; set; } //Unit of measure: °C, mSv
    [Required]
    public DateTime Timestamp { get; set; }
    
    [Required]
    [ForeignKey(nameof(Sensor))]
    public int SensorId { get; set; }
    public Sensor Sensor { get; set; }
}
