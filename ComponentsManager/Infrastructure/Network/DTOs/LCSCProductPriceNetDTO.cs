﻿using System.Text.Json.Serialization;

namespace ComponentsManager.Infrastructure.Network.DTOs;

[method: JsonConstructor]
public record LCSCProductPriceNetDTO(
    [property: JsonPropertyName("ladder")] int Ladder,
    [property: JsonPropertyName("productPrice")] string ProductPrice,
    [property: JsonPropertyName("usdPrice")] double UsdPrice,
    [property: JsonPropertyName("cnyProductPriceList")] object? CnyProductPriceList,
    [property: JsonPropertyName("discountRate")] string DiscountRate,
    [property: JsonPropertyName("currencyPrice")] double CurrencyPrice,
    [property: JsonPropertyName("currencySymbol")] string CurrencySymbol,
    [property: JsonPropertyName("isForeignDiscount")] object? IsForeignDiscount,
    [property: JsonPropertyName("ladderLevel")] object? LadderLevel
);