namespace DBManager.DTOs.Components;

public interface IComponent: IDbEntity
{
    string? Name { get; }
    string? Description { get; }
    //unique
    string? ManufacturerProductCode { get; }
    string? Manufacturer { get; }
    //unique
    string? VendorProductCode { get; }
    string? Vendor { get; }
    string? DatasheetUrl { get; }
    List<string>? ImagesUrl { get; }
}