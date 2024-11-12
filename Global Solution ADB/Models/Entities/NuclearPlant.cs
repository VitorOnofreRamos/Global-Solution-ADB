using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_NuclearPlant")]
public class NuclearPlant //Nuclear Power Plant
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string Localization { get; set; }
    [Required]
    public float FullCapacity { get; set; }
    [Required]
    public int NumberOfReactors { get; set; }
}
