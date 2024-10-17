using System.Text.Json.Serialization;

namespace DistributorManager.DTOs.LCSC;

[method: JsonConstructor]
public record LCSCRootDTO(
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("msg")] string? Msg,
    [property: JsonPropertyName("result")] LCSCPartDTO? Result
);