using System.Reflection.Emit;
using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network.DTOs.LCSC;

public class LCSCCategoryConversionMap
{
    private static readonly Dictionary<string, TopLevelCategory> _topLevelCategoryMap = new Dictionary<string, TopLevelCategory>()
    {
        {"Resistors", TopLevelCategory.Resistor},
        {"Capacitors", TopLevelCategory.Capacitor},
    };
    
    private static readonly Dictionary<string, BottomLevelCategory> _bottomLevelCategories = new Dictionary<string, BottomLevelCategory>()
    {
        {"Chip Resistor - Surface Mount", BottomLevelCategory.SurfaceMount},
        {"Aluminum Case/Porcelain Tube Resistance", BottomLevelCategory.AluminiumCase},
        {"Multilayer Ceramic Capacitors MLCC - SMD/SMT", BottomLevelCategory.Ceramic},
    };

    private static T TryParseLevelCategory<T>(Dictionary<string, T> map, string categoryName) where T : struct
    {
        return map.GetValueOrDefault(categoryName);
    }

    public static Category? TryParseCategory(string topCategoryName, string bottomCategoryName)
    {
        TopLevelCategory topLevelCategory = TryParseLevelCategory(_topLevelCategoryMap, topCategoryName);
        BottomLevelCategory bottomLevelCategory = TryParseLevelCategory(_bottomLevelCategories, bottomCategoryName);
        if (topLevelCategory == TopLevelCategory.None || bottomLevelCategory == BottomLevelCategory.None)
        {
            return null;
        }

        return new Category()
        {
            TopLevelCategory = (TopLevelCategory)topLevelCategory,
            BottomLevelCategory = bottomLevelCategory
        };
    }
}