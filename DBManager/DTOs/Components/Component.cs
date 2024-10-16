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
    protected string? _name;
    public string? Description { get; init; }
    //Unique
    public string? ManufacturerProductCode { get; init; }
    public string? Manufacturer { get; init; }
    //Unique
    public string? VendorProductCode { get; init; }
    public string? Vendor { get; init; }
    public string? DatasheetUrl { get; init; }
    public List<string>? ImagesUrl { get; init; }
}