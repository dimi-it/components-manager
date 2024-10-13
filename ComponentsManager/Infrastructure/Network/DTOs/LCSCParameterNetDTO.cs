using System.Text.Json.Serialization;

namespace ComponentsManager.Infrastructure.Network.DTOs;

[method: JsonConstructor]
public record LCSCParameterNetDTO(
    [property: JsonPropertyName("paramCode")] string ParamCode,
    [property: JsonPropertyName("paramName")] string ParamName,
    [property: JsonPropertyName("paramNameEn")] string ParamNameEn,
    [property: JsonPropertyName("paramValue")] string ParamValue,
    [property: JsonPropertyName("paramValueEn")] string ParamValueEn,
    [property: JsonPropertyName("paramValueEnForSearch")] double? ParamValueEnForSearch,
    [property: JsonPropertyName("isMain")] bool IsMain,
    [property: JsonPropertyName("sortNumber")] int SortNumber
);
