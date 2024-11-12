using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Models.Entities;

public class Sensor : _BaseEntity
{
    //[System.Diagnostics.DebuggerNonUserCode()]
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
