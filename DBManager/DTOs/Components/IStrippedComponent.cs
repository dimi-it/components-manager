namespace DBManager.DTOs.Components;

public interface IStrippedComponent: IDbEntity
{
    string? Name { get; }
    //unique
    string? ManufacturerProductCode { get; }
    string? Manufacturer { get; }
    //unique
    string? VendorProductCode { get; }
    string? Vendor { get; }
}