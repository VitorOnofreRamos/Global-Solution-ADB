﻿using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_NuclearPlant")]
public class NuclearPlant : _BaseEntity //Usina Nuclear (Nuclear Power Plant)
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } // Nome da usina nuclear
    
    [Required]
    [StringLength(100)]
    public string Localization { get; set; } // Localização da usina nuclear (ex.: cidade, país)
    
    [Range(0, 100)]
    [Column(TypeName = "NUMBER(5, 2)")]
    public float FullCapacity { get; set; } // Capacidade total de geração de energia da usina (em MW)
    
    [Required]
    public int NumberOfReactors { get; set; } // Número total de reatores nucleares na usina

    //Propriedade de navegação para as métricas associadas à usina
    public ICollection<Metric> Metrics { get; set; } = new List<Metric>();
}
