using DBManager.Const;

namespace DBManager.DTOs;

public class ParameterDTO
{
    public ParameterEnum Name { get; set; }
    public string ValueString { get; set; }
    public double? Value { get; set; }
}