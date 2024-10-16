using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DBManager.DTOs.Components;

public class Component : IComponent
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = string.Empty;
    public required string Name { get; init; }
    public string? Description { get; init; }
    //Unique
    public string? ManufacturerProductCode { get; init; }
    public string? Manufacturer { get; init; }
    //Unique
    public string? VendorProductCode { get; init; }
    public string? Vendor { get; init; }
}