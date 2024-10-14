using ComponentsManager.Infrastructure.Databases.Const;
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
        { "Operating Temperature", ParameterEnum.OperatingTemperatureRange },
        { "Resistance", ParameterEnum.Resistance },
        { "Voltage Rated", ParameterEnum.VoltageRated },
        { "Rated Voltage", ParameterEnum.VoltageRated },
        { "Capacitance", ParameterEnum.Capacitance },
        { "φD", ParameterEnum.Diameter }, 
        { "L", ParameterEnum.Lenght }, 
        { "Lead Spacing", ParameterEnum.LeadSpacing }, 
        { "Lifetime @ Temp", ParameterEnum.LifetimeTemperature }, 
        { "Ripple Current", ParameterEnum.RippleCurrent},
        { "Equivalent Series Resistance(ESR)", ParameterEnum.ESR},
    };

    public static ParameterEnum TryParseParameter(string parameterName)
    {
        return parameterNameMap.GetValueOrDefault(parameterName);
    }
}