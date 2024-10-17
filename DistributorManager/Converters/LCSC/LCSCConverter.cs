using DBManager.DTOs.Components;
using DBManager.DTOs.Components.Capacitors;
using DBManager.DTOs.Components.Resistors;
using DistributorManager.DTOs.LCSC;
using DistributorManager.Repositories.LCSC;

namespace DistributorManager.Converters.LCSC;

public static class LCSCConverter
{
    public static IComponent GetComponent(LCSCPartDTO part)
    {
        Component baseComponent = new Component()
        {
            Description = part.ProductIntroEn,
            ManufacturerProductCode = part.ProductModel,
            Manufacturer = part.BrandNameEn,
            VendorProductCode = part.ProductCode,
            Vendor = LCSCRepository.Vendor,
            DatasheetUrl = part.PdfUrl,
            ImagesUrl = part.ProductImages.ToList()
        };

        return GetFullComponent(part, baseComponent);
    }
    
    private static IComponent GetFullComponent(LCSCPartDTO part, Component baseComponent)
    {
        switch (part.ParentCatalogId)
        {
            //Resistor
            case 308:
                switch (part.CatalogId)
                {
                    //SMD
                    case 439:
                        return GetResistor_SMD(part, baseComponent);
                }
                break;
            //Capacacitor
            case 312:
                switch (part.CatalogId)
                {
                    //MLCC SMD
                    case 313:
                        return GetResistor_SMD(part, baseComponent);
                }
                break;
        }
        throw new NotImplementedException($"{part.ParentCatalogName} -> {part.CatalogName} converter not yet implemented!");
    }
    
    private static Resistor_SMD GetResistor_SMD(LCSCPartDTO part, Component baseComponent)
    {
        Dictionary<string, LCSCParameterDTO> lcscParameters =
            GetLCSCParametersDict(part.ParamList ?? throw NullParameterException(nameof(part.ParamList)));
        return new Resistor_SMD(baseComponent)
        {
            Footprint = new ComponentParameter<string>(part.EncapStandard)
                        ?? throw MissingParameterException(nameof(Resistor_SMD.Footprint)),
            Resistance = GetComponentParameter(lcscParameters, LCSCParameter.Resistance)?.Cast<double>() 
                         ?? throw MissingParameterException(nameof(Resistor_SMD.Resistance)),
            Tolerance = GetComponentParameter(lcscParameters, LCSCParameter.Tolerance)?.Cast<string>() 
                        ?? throw MissingParameterException(nameof(Resistor_SMD.Tolerance)),
            Power = GetComponentParameter(lcscParameters, LCSCParameter.Power)?.Cast<double>(),
            TemperatureCoefficient = GetComponentParameter(lcscParameters, LCSCParameter.TemperatureCoefficient)?.Cast<string>(),
            Type = GetComponentParameter(lcscParameters, LCSCParameter.Type)?.Cast<string>(),
            OverloadVoltage = GetComponentParameter(lcscParameters, LCSCParameter.OverloadVoltage)?.Cast<double>(),
            OperatingTemperatureRange = GetComponentParameter(lcscParameters, LCSCParameter.OperatingTemperature)?.Cast<string>(),
        };
    }

    private static Capacitor_MLCC_SMD GetCapacitor_MLCC_SMD(LCSCPartDTO part, Component baseComponent)
    {
        Dictionary<string, LCSCParameterDTO> lcscParameters =
            GetLCSCParametersDict(part.ParamList ?? throw NullParameterException(nameof(part.ParamList)));
        return new Capacitor_MLCC_SMD(baseComponent)
        {
            Footprint = new ComponentParameter<string>(part.EncapStandard)
                        ?? throw MissingParameterException(nameof(Capacitor_MLCC_SMD.Footprint)),
            Capacitance = GetComponentParameter(lcscParameters, LCSCParameter.Capacitance)?.Cast<double>()
                          ?? throw MissingParameterException(nameof(Capacitor_MLCC_SMD.Capacitance)),
            Tolerance = GetComponentParameter(lcscParameters, LCSCParameter.Tolerance)?.Cast<string>()
                        ?? throw MissingParameterException(nameof(Capacitor_MLCC_SMD.Tolerance)),
            RatedVoltage = GetComponentParameter(lcscParameters, LCSCParameter.RatedVoltage)?.Cast<double>()
                           ?? throw MissingParameterException(nameof(Capacitor_MLCC_SMD.RatedVoltage)),
            TemperatureCoefficient = GetComponentParameter(lcscParameters, LCSCParameter.TemperatureCoefficient)?.Cast<string>()
        };
    }

    private static Dictionary<string, LCSCParameterDTO> GetLCSCParametersDict(IEnumerable<LCSCParameterDTO> parameters)
    {
        Dictionary<string, LCSCParameterDTO> lcscParameters = new Dictionary<string, LCSCParameterDTO>();
        foreach (LCSCParameterDTO parameter in parameters)
        {
            lcscParameters.Add(parameter.ParamNameEn, parameter);
        }

        return lcscParameters;
    }

    private static ComponentParameter<IConvertible>? GetComponentParameter(
        Dictionary<string, LCSCParameterDTO> lcscParameters,
        string name
        )
    {
        if (lcscParameters.TryGetValue(name, out LCSCParameterDTO parameterDto))
        {
            if (parameterDto.ParamValueEnForSearch is null or -1.0d)
            {
                return new ComponentParameter<IConvertible>(parameterDto.ParamValueEn);
            }
            else
            {
                return new ComponentParameter<IConvertible>(parameterDto.ParamValueEnForSearch, parameterDto.ParamValueEn);
            }
        }

        return null;
    } 
    
    private static InvalidOperationException MissingParameterException(string parameterName) => 
        new InvalidOperationException($"The parameter \"{parameterName}\" is essential!");

    private static ArgumentNullException NullParameterException(string parameterName) => 
        new ArgumentNullException(parameterName, "The parameter list cannot be null. Missing essential fields.");
}