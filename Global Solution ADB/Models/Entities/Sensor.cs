using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_Sensor")]
public class Sensor : _BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    public EnumSensorType Type { get; set; } //e.g., Temperature, Radiation, etc.
    [StringLength(100)]
    public string Location { get; set; }
    [Required]
    public bool Status { get; set; } // Active or Inactive
}
