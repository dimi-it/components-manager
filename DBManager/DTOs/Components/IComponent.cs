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
    public string? DatasheetUrl { get; }
    public List<string>? ImagesUrl { get; }
}