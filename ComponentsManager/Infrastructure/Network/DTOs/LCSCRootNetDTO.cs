using System.Text.Json.Serialization;

namespace ComponentsManager.Infrastructure.Network.DTOs;

[method: JsonConstructor]
public record LCSCRootNetDTO(
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("msg")] string? Msg,
    [property: JsonPropertyName("result")] LCSCResultNetDTO? Result
);