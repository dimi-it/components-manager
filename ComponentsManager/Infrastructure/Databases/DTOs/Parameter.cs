namespace ComponentsManager.Infrastructure.Databases.DTOs;

public class Parameter
{
    public ParameterEnum Name { get; set; }
    public string ValueString { get; set; }
    public double? Value { get; set; }
}