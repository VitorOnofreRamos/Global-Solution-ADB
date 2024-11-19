using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Application.ViewModels;

public class NuclearPlantViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal FullCapacity { get; set; }
    public int NumberOfReactors { get; set; }
}
