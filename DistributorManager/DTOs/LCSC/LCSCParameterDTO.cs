using System.Text.Json.Serialization;

namespace DistributorManager.DTOs.LCSC;

[method: JsonConstructor]
public record LCSCParameterDTO(
    [property: JsonPropertyName("paramCode")] string ParamCode,
    [property: JsonPropertyName("paramName")] string ParamName,
    [property: JsonPropertyName("paramNameEn")] string ParamNameEn,
    [property: JsonPropertyName("paramValue")] string ParamValue,
    [property: JsonPropertyName("paramValueEn")] string ParamValueEn,
    [property: JsonPropertyName("paramValueEnForSearch")] double? ParamValueEnForSearch,
    [property: JsonPropertyName("isMain")] bool? IsMain,
    [property: JsonPropertyName("sortNumber")] int SortNumber
);
