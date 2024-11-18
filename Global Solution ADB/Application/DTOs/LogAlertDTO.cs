using Global_Solution_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.DTOs;

public class LogAlertDTO
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "A descrição do alerta é obrigatório.")]
    [StringLength(100, ErrorMessage = "A descrição do alerta não pode conter mais de 100 caracteres.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "A data e hora do alarme é obrigatório.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime TriggeredAt { get; set; } = DateTime.Now;

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ResolvedAt { get; set; }

    [Required(ErrorMessage = "O estado do alerta é obrigatório.")]
    public bool IsResolved { get; set; } = false; // true if resolved, false if unresolved

    [Required(ErrorMessage = "O Id da Análise é obrigatório.")]
    public int AnalysisId { get; set; }
    public virtual Analysis Analysis { get; set; }
}
