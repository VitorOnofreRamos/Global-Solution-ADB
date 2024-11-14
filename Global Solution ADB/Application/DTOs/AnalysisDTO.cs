using Global_Solution_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.DTOs;

public class AnalysisDTO
{
    public int? Id { get; set; }
    
    [Required(ErrorMessage = "O valor da análise é obrigatório.")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "A data e hora da Análise é obrigatória.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Timestamp { get; set; } = DateTime.Now;


    [Required(ErrorMessage = "O Id do Sensor é obrigatório")]
    public int SensorId { get; set; }
    public virtual Sensor Sensor { get; set; }

    // Navegação
    public ICollection<AlertDTO> LogAlerts { get; set; } = new List<AlertDTO>();
}
