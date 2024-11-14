using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("ANALYSIS")]
public class Analysis : _BaseEntity
{
    [Column("ANALYSISVALUE", TypeName = "NUMBER")]
    [Required]
    public decimal Value { get; set; }

    [Column("ANALYSISTIMESTAMP")]
    [Required]
    public DateTime Timestamp { get; set; } = DateTime.Now;

    [Column("ID_SENSOR")]
    [Required]
    [ForeignKey(nameof(Sensor))]
    public int SensorId { get; set; }
    public virtual Sensor Sensor { get; set; }

    // Navegação
    public ICollection<LogAlert> LogAlerts { get; set; } = new List<LogAlert>();
}
