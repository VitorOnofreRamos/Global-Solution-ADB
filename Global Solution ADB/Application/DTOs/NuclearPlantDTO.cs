using Global_Solution_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.DTOs;

public class NuclearPlantDTO
{
    public int? Id { get; set; }
    
    [Required(ErrorMessage = "O nome da usina é obrigatório.")]
    [StringLength(50, ErrorMessage = "O nome da usina só pode conter 50 Caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A capacidade total da usina é obrigatória.")]
    public decimal FullCapacity { get; set; }

    [Required(ErrorMessage = "O número de reactores da usina é obrigatório.")]
    public int NumberOfReactors { get; set; }

    public ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
    public ICollection<Metric> Metrics { get; set; } = new List<Metric>();
}
