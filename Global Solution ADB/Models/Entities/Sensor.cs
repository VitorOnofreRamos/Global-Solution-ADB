using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_Sensor")]
public class Sensor : _BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } // Nome ou identificação do sensor
    
    [Required]
    [EnumDataType(typeof(EnumSensorType))]
    public EnumSensorType Type { get; set; } // Tipo do sensor (ex.: Temperatura, Radiação)
    
    [StringLength(100)]
    public string Location { get; set; } // Localização do sensor dentro da usina (ex.: Reator, Sistema de Resfriamento)
    
    [Required]
    [Column(TypeName = "NUMBER(1)")]
    public bool Status { get; set; } // Status operacional do sensor (0 = inativo, 1 = ativo)

    //Propriedades de navegação para as análises e alertas associadas ao sensor
    public ICollection<Analysis> Analyses { get; set; } = new List<Analysis>();
    public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
}
