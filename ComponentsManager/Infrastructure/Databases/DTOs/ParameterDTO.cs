using ComponentsManager.Infrastructure.Databases.Const;

namespace ComponentsManager.Infrastructure.Databases.DTOs;

public class ParameterDTO
{
    public ParameterEnum Name { get; set; }
    public string ValueString { get; set; }
    public double? Value { get; set; }
}