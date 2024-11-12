using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Models.Entities;

public class SystemConfig : _BaseEntity
{
    [Required]
    public EnumSensorType SensorType { get; set; }
    public double? ThresholdMin { get; set; } // Minimum threshold for alerts
    public double? ThresholdMax { get; set; } // Maximum threshold for alerts
    [Required]
    public EnumAlertLevel AlertLevel { get; set; }
}
