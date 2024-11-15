using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Models.Entities;

[Table("SENSORTYPE")]
public class SensorType : _BaseEntity
{
    [Column("SPECIFICTYPE")]
    [Required]
    [StringLength(50)]
    public string SpecificType { get; set; }

    [Column("ID_SENSOR")]
    [Required]
    [ForeignKey(nameof(Sensor))]
    public int SensorId { get; set; }
    public virtual Sensor Sensor { get; set; }
}
