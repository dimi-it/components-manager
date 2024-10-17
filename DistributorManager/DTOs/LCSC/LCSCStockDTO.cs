using System.Text.Json.Serialization;

namespace DistributorManager.DTOs.LCSC;

[method: JsonConstructor]
public record LCSCStockDTO(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("shipImmediately")] int ShipImmediately,
    [property: JsonPropertyName("ship3Days")] int Ship3Days
);