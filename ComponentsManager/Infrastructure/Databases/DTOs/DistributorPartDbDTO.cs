using System.Text.Json;
using System.Text.Json.Serialization;
using ComponentsManager.Infrastructure.Network;

namespace ComponentsManager.Infrastructure.Databases.DTOs;

public class DistributorPartDbDTO: IPartDbDTO
{
    public long ProductId { get; set; }
    public string ManufacturerProductCode { get; set; }
    public string Manufacturer { get; set; }
    public string VendorProductCode { get; set; }
    public NetworkProvider Vendor { get; set; }
    public Category Category { get; set; }
    public List<Parameter> Parameters { get; set; }
    public string? DatasheetUrl { get; set; }
    public List<string> ImagesUrl { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}