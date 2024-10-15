using DBManager.Const;
using DBManager.DTOs;

namespace ComponentsManager.Infrastructure.Network.LCSC.Maps;
//Two level way conversion to be implemented(Dictionary<Type<string, string>, Enum>)
//or
//Category TREE classes
public class LCSCCategoryConversionMap
{
    private static readonly Dictionary<string, TopLevelCategory> _topLevelCategoryMap = new Dictionary<string, TopLevelCategory>()
    {
        {"Resistors", TopLevelCategory.Resistor},
        {"Capacitors", TopLevelCategory.Capacitor},
        {"Circuit Protection", TopLevelCategory.CircuitProtection},
        {"Connectors", TopLevelCategory.Connector},
        {"Diodes", TopLevelCategory.Diode},
        {"Relays", TopLevelCategory.Relay},
        {"Inductors, Coils, Chokes", TopLevelCategory.Coil},
        {"Optoelectronics", TopLevelCategory.Optoelectronic},
        {"Switches", TopLevelCategory.Switch},
        {"IoT/Communication Modules", TopLevelCategory.CommunicationModule},
        {"Transistors/Thyristors", TopLevelCategory.Transistor},
        {"Power Management (PMIC)", TopLevelCategory.PowerManagement}
    };
    
    private static readonly Dictionary<string, BottomLevelCategory> _bottomLevelCategories = new Dictionary<string, BottomLevelCategory>()
    {
        {"Chip Resistor - Surface Mount", BottomLevelCategory.ResistorSMD},
        {"Aluminum Case/Porcelain Tube Resistance", BottomLevelCategory.AluminiumCase},
        {"Multilayer Ceramic Capacitors MLCC - SMD/SMT", BottomLevelCategory.CapacitorCeramicSMD},
        {"Aluminum Electrolytic Capacitors - SMD", BottomLevelCategory.CapacitorAluminiumSMD},
        {"Aluminum Electrolytic Capacitors - Leaded", BottomLevelCategory.CapacitorAluminiumLeaded},
        {"Pluggable System Terminal Block", BottomLevelCategory.TerminalBlock},
        {"ESD and Surge Protection (TVS/ESD)", BottomLevelCategory.ESD},
        {"Schottky Diodes", BottomLevelCategory.Schottky},
        {"Switching Diodes", BottomLevelCategory.Switching},
        {"Resettable Fuses", BottomLevelCategory.ResettableFuse},
        {"Power Relays", BottomLevelCategory.PowerRelay},
        {"Inductors (SMD)", BottomLevelCategory.InductorSMD},
        {"LED Indication - Discrete", BottomLevelCategory.LedIndication},
        {"Tactile Switches", BottomLevelCategory.Tactile},
        {"WiFi Modules", BottomLevelCategory.WiFi},
        {"Voltage Regulators - Linear, Low Drop Out (LDO) Regulators", BottomLevelCategory.LDO},
        {"DC-DC Converters", BottomLevelCategory.DCDC},
        {"USB Connectors", BottomLevelCategory.USB},
        {"MOSFETs", BottomLevelCategory.Mosfet},
    };

    private static T TryParseLevelCategory<T>(Dictionary<string, T> map, string categoryName) where T : struct
    {
        return map.GetValueOrDefault(categoryName);
    }

    public static CategoryDTO? TryParseCategory(string topCategoryName, string bottomCategoryName)
    {
        TopLevelCategory topLevelCategory = TryParseLevelCategory(_topLevelCategoryMap, topCategoryName);
        BottomLevelCategory bottomLevelCategory = TryParseLevelCategory(_bottomLevelCategories, bottomCategoryName);
        if (topLevelCategory == TopLevelCategory.None || bottomLevelCategory == BottomLevelCategory.None)
        {
            return null;
        }

        return new CategoryDTO()
        {
            TopLevelCategory = (TopLevelCategory)topLevelCategory,
            BottomLevelCategory = bottomLevelCategory
        };
    }
}