using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DBManager.DTOs;

public class DistributorPartDbDTO: IPartDbDTO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ManufacturerProductCode { get; set; }
    public string Manufacturer { get; set; }
    public string VendorProductCode { get; set; }
    // public NetworkProvider Vendor { get; set; } //NO BUENOOO REFERENCE OTHER PROJECT
    public CategoryDTO CategoryDto { get; set; }
    public List<ParameterDTO> Parameters { get; set; }
    
    //descpription
    public string? DatasheetUrl { get; set; }
    public List<string> ImagesUrl { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}