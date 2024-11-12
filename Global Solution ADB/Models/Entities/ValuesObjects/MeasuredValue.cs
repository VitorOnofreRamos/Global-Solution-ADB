using Global_Solution_ADB.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution_ADB.Models.Entities.ValueObjects;

[Owned]
public class MeasuredValue
{
    public double Valor { get; private set; }
    public EnumAnalysisUnit Unidade { get; private set; }
    public DateTime DataMedicao { get; private set; }

    public MeasuredValue(double value, EnumAnalysisUnit unit)
    {
        Valor = value;
        Unidade = unit;
        DataMedicao = DateTime.UtcNow; // Define a data automaticamente no momento da medição
    }

    public override string ToString()
    {
        return $"{Valor} {Unidade} (em {DataMedicao})";
    }
}
