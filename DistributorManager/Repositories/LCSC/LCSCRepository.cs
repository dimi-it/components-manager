using System.Net.Http.Headers;
using System.Text.Json;
using DistributorManager.DTOs.LCSC;

namespace DistributorManager.Repositories.LCSC;

public class LCSCRepository : BaseDistributorRepository<LCSCPartDTO>
{
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
        IDistributorRepository<LCSCPartDTO> f = this;
    }

    public override async Task<LCSCPartDTO?> GetPartNetAsync(string productCode)
    {
        await using Stream stream = await _httpClient
            .GetStreamAsync($"ftps/wm/product/detail?productCode={productCode}");
        LCSCRootDTO? lcscRootNetDto = await JsonSerializer.DeserializeAsync<LCSCRootDTO>(stream);
        return lcscRootNetDto?.Result;
    }
}