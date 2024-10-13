using System.Text.Json.Serialization;
using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network.DTOs.LCSC;

[method: JsonConstructor]
public record LCSCPartNetDto(
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
        [property: JsonPropertyName("domesticStockVO")] LCSCStockNetDTO DomesticStock,
        [property: JsonPropertyName("overseasStockVO")] LCSCStockNetDTO OverseasStock,
        [property: JsonPropertyName("productPriceList")] IReadOnlyList<LCSCProductPriceNetDTO> ProductPriceList,
        [property: JsonPropertyName("productImages")] IReadOnlyList<string> ProductImages,
        [property: JsonPropertyName("pdfUrl")] string? PdfUrl,
        [property: JsonPropertyName("productDescEn")] string? ProductDescEn,
        [property: JsonPropertyName("productIntroEn")] string ProductIntroEn,
        [property: JsonPropertyName("paramVOList")] IReadOnlyList<LCSCParameterNetDTO> ParamList,
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
) : IPartNetDTO
{
        public DistributorPartDbDTO ToDistributorPartDbDTO()
        {
                return new DistributorPartDbDTO()
                {
                        ManufacturerProductCode = ProductCode,
                        Manufacturer = BrandNameEn,
                        VendorProductCode = ProductCode,
                        Vendor = NetworkProvider.LCSC,
                        Category = LCSCCategoryConversionMap.TryParseCategory(ParentCatalogName, CatalogName) 
                                   ?? throw new ArgumentNullException("Category", $"{ParentCatalogName}_{CatalogName}"),
                        Parameters = ParseParameters(),
                        DatasheetUrl = PdfUrl,
                        ImagesUrl = ProductImages as List<string> ?? new List<string>()
                };
        }

        public List<Parameter> ParseParameters()
        {
                List<Parameter> parameters = new List<Parameter>();
                foreach (LCSCParameterNetDTO lcscParameter in ParamList)
                {
                        Parameter parameter = TryParseParameter(lcscParameter) 
                                              ?? throw new ArgumentNullException("Parameter", lcscParameter.ParamNameEn);
                        parameters.Add(parameter);
                }
                //add footprint
                parameters.Add(new Parameter()
                {
                        Name = ParameterEnum.Footprint,
                        ValueString = EncapStandard,
                        Value = null
                });
                
                return parameters;
        }

        public Parameter? TryParseParameter(LCSCParameterNetDTO lcscParameter)
        {
                ParameterEnum parameterName = LCSCParameterConversionMap.TryParseParameter(lcscParameter.ParamNameEn);
                if(parameterName != ParameterEnum.None)
                {
                        return new Parameter()
                        {
                                Name = parameterName,
                                ValueString = lcscParameter.ParamValueEn,
                                Value = lcscParameter.ParamValueEnForSearch == -1.0d
                                        ? null
                                        : lcscParameter.ParamValueEnForSearch
                        };
                }

                return null;
        }
}