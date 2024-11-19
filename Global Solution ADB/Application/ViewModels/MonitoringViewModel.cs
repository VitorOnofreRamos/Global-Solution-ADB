namespace Global_Solution_ADB.Application.ViewModels;

public class MonitoringViewModel
{
    public string NuclearPlantName { get; set; }
    public IEnumerable<SensorViewModel> Sensors { get; set; }
}
