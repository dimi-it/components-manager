using DBManager.Const;

namespace DBManager.DTOs;

public class CategoryDTO
{
    public TopLevelCategory TopLevelCategory { get; set; }
    public BottomLevelCategory BottomLevelCategory { get; set; }
}