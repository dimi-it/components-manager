using ComponentsManager.Infrastructure.Databases.Const;

namespace ComponentsManager.Infrastructure.Databases.DTOs;

public class CategoryDTO
{
    public TopLevelCategory TopLevelCategory { get; set; }
    public BottomLevelCategory BottomLevelCategory { get; set; }
}