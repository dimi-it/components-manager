using ComponentsManager.Infrastructure.Databases.Const;
using ComponentsManager.Infrastructure.Databases.DTOs;

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