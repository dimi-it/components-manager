using System.Text.Json.Serialization;

namespace ComponentsManager.Infrastructure.Network.LCSC.DTOs;

[method: JsonConstructor]
public record LCSCStockNetDTO(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("shipImmediately")] int ShipImmediately,
    [property: JsonPropertyName("ship3Days")] int Ship3Days
);