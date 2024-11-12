using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_Alert")]
public class Alert : _BaseEntity
{
    [Required]
    public EnumAlertLevel Level { get; set; } // Alert severity level, e.g., Low, Medium, High, Critical
    [StringLength(255)]
    public string Description { get; set; }
    [Required]
    public DateTime TriggeredAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public bool IsResolved { get; set; } = false;

    [Required]
    [ForeignKey(nameof(Sensor))]
    public int SensorId { get; set; }
    public Sensor Sensor { get; set; }
}
