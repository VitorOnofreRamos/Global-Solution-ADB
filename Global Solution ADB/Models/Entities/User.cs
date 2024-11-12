using Global_Solution_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution_ADB.Models.Entities;

[Table("GlobalEnergy_User")]
public class User : _BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public EnumUserRole Role { get; set; } // e.g., Operator, Technician, Administrator

    [Required]
    public string PasswordHash { get; set; } // Storing password hash for security

    public DateTime LastLoginAt { get; set; }
}
