using System.Text.Json.Serialization;
using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network.DTOs;

[method: JsonConstructor]
public record LCSCResultNetDTO(
        [property: JsonPropertyName("productId")] int ProductId,
        [property: JsonPropertyName("productCode")] string ProductCode,
        [property: JsonPropertyName("productModel")] string ProductModel,
        [property: JsonPropertyName("parentCatalogId")] int ParentCatalogId,
        [property: JsonPropertyName("parentCatalogName")] string ParentCatalogName,
        [property: JsonPropertyName("catalogId")] int CatalogId,
        [property: JsonPropertyName("catalogName")] string CatalogName,
        [property: JsonPropertyName("brandId")] int BrandId,
        [property: JsonPropertyName("brandNameEn")] string BrandNameEn,
        [property: JsonPropertyName("encapStandard")] string EncapStandard,
        [property: JsonPropertyName("split")] int Split,
        [property: JsonPropertyName("productUnit")] string ProductUnit,
        [property: JsonPropertyName("minPacketUnit")] string MinPacketUnit,
        [property: JsonPropertyName("minBuyNumber")] int MinBuyNumber,
        [property: JsonPropertyName("maxBuyNumber")] int MaxBuyNumber,
        [property: JsonPropertyName("minPacketNumber")] int MinPacketNumber,
        [property: JsonPropertyName("isEnvironment")] bool IsEnvironment,
        [property: JsonPropertyName("allHotLevel")] object? AllHotLevel,
        [property: JsonPropertyName("isHot")] bool IsHot,
        [property: JsonPropertyName("isPreSale")] bool IsPreSale,
        [property: JsonPropertyName("isReel")] bool IsReel,
        [property: JsonPropertyName("reelPrice")] double ReelPrice,
        [property: JsonPropertyName("stockNumber")] int StockNumber,
        [property: JsonPropertyName("stockSz")] int StockSz,
        [property: JsonPropertyName("stockJs")] int StockJs,
        [property: JsonPropertyName("wmStockHk")] int WmStockHk,
        [property: JsonPropertyName("domesticStockVO")] LCSCStockNetDTO DomesticStockVO,
        [property: JsonPropertyName("overseasStockVO")] LCSCStockNetDTO OverseasStockVO,
        [property: JsonPropertyName("productPriceList")] IReadOnlyList<LCSCProductPriceNetDTO> ProductPriceList,
        [property: JsonPropertyName("productImages")] IReadOnlyList<string> ProductImages,
        [property: JsonPropertyName("pdfUrl")] string PdfUrl,
        [property: JsonPropertyName("productDescEn")] string? ProductDescEn,
        [property: JsonPropertyName("productIntroEn")] string ProductIntroEn,
        [property: JsonPropertyName("paramVOList")] IReadOnlyList<LCSCParameterNetDTO> ParamVOList,
        [property: JsonPropertyName("productArrange")] string ProductArrange,
        [property: JsonPropertyName("productWeight")] double ProductWeight,
        [property: JsonPropertyName("foreignWeight")] object? ForeignWeight,
        [property: JsonPropertyName("isForeignOnsale")] bool IsForeignOnsale,
        [property: JsonPropertyName("isAutoOffsale")] bool IsAutoOffsale,
        [property: JsonPropertyName("isHasBattery")] bool IsHasBattery,
        [property: JsonPropertyName("pdfLinkUrl")] string? PdfLinkUrl,
        [property: JsonPropertyName("productLadderPrice")] object? ProductLadderPrice,
        [property: JsonPropertyName("ladderDiscountRate")] object? LadderDiscountRate,
        [property: JsonPropertyName("eccn")] string Eccn,
        [property: JsonPropertyName("currencyType")] string CurrencyType,
        [property: JsonPropertyName("currencySymbol")] string CurrencySymbol,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("weight")] double Weight,
        [property: JsonPropertyName("hasThirdPartyStock")] bool HasThirdPartyStock,
        [property: JsonPropertyName("flashSaleProductPO")] object? FlashSaleProductPO
) : IResultNetDTO
{
        public IPartDbDTO ToPartDbDTO()
        {
                throw new NotImplementedException();
        }
}