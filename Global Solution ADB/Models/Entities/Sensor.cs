using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("SENSOR")]
public class Sensor : _BaseEntity
{
    [Column("SENSORNAME")]
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Column("MACHINARYLOCATION")]
    [Required]
    [StringLength(50)]
    public string MachinaryLocation { get; set; }

    [Column("STATUS")]
    [Required]
    public bool Status { get; set; } // Status operacional do sensor (0 = inativo, 1 = ativo)

    [Column("ID_NUCLEARPLANT")]
    [Required]
    [ForeignKey(nameof(NuclearPlant))]
    public int NuclearPlantId { get; set; }
    public virtual NuclearPlant NuclearPlant { get; set; }

    //Navegação
    public ICollection<Analysis> Analyses { get; set; } = new List<Analysis>();
}
