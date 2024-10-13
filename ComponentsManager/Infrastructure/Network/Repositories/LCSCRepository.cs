using System.Net.Http.Headers;
using System.Text.Json;
using ComponentsManager.Infrastructure.Network.DTOs;
using ComponentsManager.Infrastructure.Network.DTOs.LCSC;

namespace ComponentsManager.Infrastructure.Network.Repositories;

public class LCSCRepository : INetRepository<LCSCPartNetDto>
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
    }

    public async Task<LCSCPartNetDto?> GetPartNetAsync(string productCode)
    {
        await using Stream stream = await _httpClient
            .GetStreamAsync($"ftps/wm/product/detail?productCode={productCode}");
        LCSCRootNetDTO? lcscRootNetDto = await JsonSerializer.DeserializeAsync<LCSCRootNetDTO>(stream);
        return lcscRootNetDto?.Result;
    }
}