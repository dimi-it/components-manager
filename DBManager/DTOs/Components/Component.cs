using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DBManager.DTOs.Components;

public class Component : IComponent
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = string.Empty;
    
    //Nullable but cannot be stored with a Name null
    public string? Name
    {
        get => _name;
        init => _name = value;
    }
    public string? Description
    {
        get => _description;
        init => _description = value;
    }

    //Unique
    public string? ManufacturerProductCode
    {
        get => _manufacturerProductCode;
        init => _manufacturerProductCode = value;
    }

    public string? Manufacturer
    {
        get => _manufacturer;
        init => _manufacturer = value;
    }

    //Unique
    public string? VendorProductCode
    {
        get => _vendorProductCode;
        init => _vendorProductCode = value;
    }

    public string? Vendor
    {
        get => _vendor;
        init => _vendor = value;
    }

    public string? DatasheetUrl
    {
        get => _datasheetUrl;
        init => _datasheetUrl = value;
    }

    public List<string>? ImagesUrl
    {
        get => _imagesUrl;
        init => _imagesUrl = value;
    }

    private string? _name;
    private string? _description;
    private string? _manufacturerProductCode;
    private string? _manufacturer;
    private string? _vendorProductCode;
    private string? _vendor;
    private string? _datasheetUrl;
    private List<string>? _imagesUrl;

    protected void InitByInstance(Component component)
    {
        _name = component.Name;
        _description = component.Description;
        _manufacturerProductCode = component.ManufacturerProductCode;
        _manufacturer = component.Manufacturer;
        _vendorProductCode = component.VendorProductCode;
        _vendor = component.Vendor;
        _datasheetUrl = component.DatasheetUrl;
        _imagesUrl = component.ImagesUrl;
    }

    protected void SetName(string name)
    {
        _name = name;
    }
}