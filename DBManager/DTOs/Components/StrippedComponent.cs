namespace DBManager.DTOs.Components;

public class StrippedComponent: IStrippedComponent
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    //unique
    public string? ManufacturerProductCode { get; init; }
    public string? Manufacturer { get; init; }
    //unique
    public string? VendorProductCode { get; init; }
    public string? Vendor { get; init; }
    public required string Collection { get; init; }
}

public static class ExtensionStrippedComponent
{
    public static StrippedComponent ToStripped(this IComponent component)
    {
        return new StrippedComponent()
        {
            Id = component.Id,
            Name = component.Name,
            ManufacturerProductCode = component.ManufacturerProductCode,
            Manufacturer = component.Manufacturer,
            VendorProductCode = component.VendorProductCode,
            Vendor = component.Vendor,
            Collection = component.GetType().ToString().Split(".").Last()
        };
    }
}