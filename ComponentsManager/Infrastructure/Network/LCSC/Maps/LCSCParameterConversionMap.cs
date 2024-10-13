using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network.LCSC.Maps;

public static class LCSCParameterConversionMap
{
    private static readonly Dictionary<string, ParameterEnum> parameterNameMap = new Dictionary<string, ParameterEnum>()
    {
        { "Power(Watts)", ParameterEnum.Power },
        { "Type", ParameterEnum.Type },
        { "Overload Voltage (Max)", ParameterEnum.OverloadVoltage },
        { "Temperature Coefficient", ParameterEnum.TemperatureCoefficient },
        { "Tolerance", ParameterEnum.Tolerance },
        { "Operating Temperature Range", ParameterEnum.OperatingTemperatureRange },
        { "Resistance", ParameterEnum.Resistance },
        {"Voltage Rated", ParameterEnum.VoltageRated},
        {"Capacitance", ParameterEnum.Capacitance},
    };

    public static ParameterEnum TryParseParameter(string parameterName)
    {
        return parameterNameMap.GetValueOrDefault(parameterName);
    }
}