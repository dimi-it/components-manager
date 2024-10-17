using System.Net.Http.Headers;
using System.Text.Json;
using DBManager.DTOs.Components;
using DBManager.DTOs.Components.Capacitors;
using DBManager.DTOs.Components.Resistors;
using DBManager.Repositories;
using DBManager.Repositories.Components.Capacitor;
using DBManager.Repositories.Components.Resistor;
using DistributorManager.Converters;
using DistributorManager.Converters.LCSC;
using DistributorManager.DTOs.LCSC;

namespace DistributorManager.Repositories.LCSC;

public class LCSCRepository : IDistributorRepository<LCSCPartDTO>
{
    public static string Vendor => "LCSC";
    
    private readonly string _baseAddress = "https://wmsc.lcsc.com";
    private HttpClient _httpClient;

    public LCSCRepository(string? baseAddress = null)
    {
        _baseAddress = baseAddress ?? _baseAddress;
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_baseAddress)
        };
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("User-Agent","Other");
    }

    public async Task<LCSCPartDTO?> GetPartAsync(string productCode)
    {
        await using Stream stream = await _httpClient
            .GetStreamAsync($"ftps/wm/product/detail?productCode={productCode}");
        LCSCRootDTO? lcscRootNetDto = await JsonSerializer.DeserializeAsync<LCSCRootDTO>(stream);
        return lcscRootNetDto?.Result;
    }

    public IComponent GetComponent(LCSCPartDTO part)
    {
        return LCSCConverter.GetComponent(part);
    }

    public async Task InsertPartIntoDb(MongoConnection mongoConnection, LCSCPartDTO part)
    {
        IComponent component = GetComponent(part);
        
        switch (component)
        {
            case Resistor_SMD resistorSmd:
                await new Resistor_SMDRepository(mongoConnection).CreateAsync(resistorSmd);
                break;
            case Capacitor_MLCC_SMD capacitorMlccSmd:
                await new Capacitor_MLCC_SMDRepository(mongoConnection).CreateAsync(capacitorMlccSmd);
                break;
            default:
                throw new NotImplementedException($"{part.ParentCatalogName} -> {part.CatalogName} DB not yet implemented!");
        }
    }
}