using Global_Solution_ADB.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Global_Solution_ADB.Models.Entities.ValueObjects;

[Owned]
public class Thresholds
{
    public EnumSensorType SensorType { get; private set; } // Tipo de sensor ao qual a configuração se aplica
    public double LimiteMinimo { get; private set; } // Limite mínimo permitido
    public double LimiteMaximo { get; private set; } // Limite máximo permitido
    public EnumAlertLevel AlertLevel { get; private set; } // Nível de severidade

    public Thresholds(EnumSensorType sensorType, double limiteMinimo, double limiteMaximo, EnumAlertLevel nivelAlerta)
    {
        SensorType = sensorType;
        LimiteMinimo = limiteMinimo;
        LimiteMaximo = limiteMaximo;
        AlertLevel = nivelAlerta;
    }

    public override string ToString()
    {
        return $"{SensorType}: {LimiteMinimo} - {LimiteMaximo}, Nível: {AlertLevel}";
    }
}
