using Global_Solution_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.DTOs;

public class MetricDTO
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "A data e hora da medição é obrigatória.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime MetricDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "ElectricityProvided.")]
    public decimal ElectricityProvided { get; set; }

    [Required(ErrorMessage = "NuclearParticipation.")]
    public decimal NuclearParticipation { get; set; }

    [Required(ErrorMessage = "OperationalEfficiency.")]
    public decimal OperationalEfficiency { get; set; }

    [Required(ErrorMessage = "O Id da Usina Nuclear é obrigatório.")]
    public int NuclearPlantId { get; set; }
    public virtual NuclearPlant NuclearPlant { get; set; }
}
