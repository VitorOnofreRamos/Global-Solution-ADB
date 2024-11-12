using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_Alert")]
public class Alert : _BaseEntity
{
    [Required]
    [EnumDataType(typeof(EnumAlertLevel))]
    public EnumAlertLevel Level { get; set; } // Nível de severidade do alertas (ex.: Low, Medium, High, Critical)
    
    [StringLength(255)]
    public string Description { get; set; } // Descrição detalhada do alerta, incluindo possíveis causas e medidas corretivas
    
    [Required]
    public DateTime TriggeredAt { get; set; } // Data e hora em que o alerta foi ativado
   
    public DateTime? ResolvedAt { get; set; } // Data e hora em que o alerta foi resolvido (nulo se ainda estiver ativo)
    
    [Column(TypeName = "NUMBER(1)")]
    public bool IsResolved { get; set; } = false; // Status de resolução do alerta (0 = não resolvido, 1 = resolvido)


    [Required]
    [ForeignKey(nameof(Sensor))]
    public int SensorId { get; set; } // ID do sensor que gerou o alerta
    public Sensor Sensor { get; set; } // Referência ao sensor associado ao alerta
}
