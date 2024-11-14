using Global_Solution_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.DTOs;

public class SensorDTO
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "O nome do sensor é obrigatório.")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "O maquinário onde se localiza o sensor é obrigatório.")]
    [StringLength(50)]
    public string MachinaryLocation { get; set; }

    [Required(ErrorMessage = "O Status da sensor é obrigatório.")]
    public bool Status { get; set; } // Status operacional do sensor (0 = inativo, 1 = ativo)

    [Required(ErrorMessage = "O Id da Usina Nuclear é obrigatório.")]
    public int NuclearPlantId { get; set; }
    public virtual NuclearPlant NuclearPlant { get; set; }

    //Navegação
    public ICollection<Analysis> Analyses { get; set; } = new List<Analysis>();
}
