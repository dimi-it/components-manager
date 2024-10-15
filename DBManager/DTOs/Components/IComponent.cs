namespace DBManager.DTOs.Components;

public interface IComponent: IDbEntity
{
    string Name { get; init; }
    string? Description { get; init; }
    string? ManufacturerProductCode { get; init; }
    string? Manufacturer { get; init; }
    string? VendorProductCode { get; init; }
    string? Vendor { get; init; }
}