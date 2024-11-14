using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("ALERT")]
public class Alert : _BaseEntity
{
    [Column("ALERTDESCRIPTION")]
    [Required]
    [StringLength(100)]
    public string Description { get; set; }

    [Column("TRIGGEREDAT")]
    [Required]
    public DateTime TriggeredAt { get; set; } = DateTime.Now;

    [Column("RESOLVEDAT")]
    public DateTime? ResolvedAt { get; set; }

    [Column("ISRESOLVED")]
    [Required]
    public bool IsResolved { get; set; } = false; // true if resolved, false if unresolved

    [Column("ID_ANALYSIS")]
    [Required]
    [ForeignKey(nameof(Analysis))]
    public int AnalysisId { get; set; }
    public virtual Analysis Analysis { get; set; }
}
