using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("NUCLEARPLANT")]
public class NuclearPlant : _BaseEntity //Usina Nuclear (Nuclear Power Plant)
{
    [Column("PLANTNAME")]
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Column("FULLCAPACITY", TypeName = "NUMBER")]
    [Required]
    public decimal FullCapacity { get; set; }

    [Column("NUMBEROFREACTORS")]
    [Required]
    public int NumberOfReactors { get; set; }

    // Navegação
    public ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
    public ICollection<Metric> Metrics { get; set; } = new List<Metric>();
}
