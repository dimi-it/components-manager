﻿using System.Net.Http.Headers;
using System.Text.Json;
using ComponentsManager.Infrastructure.Network.LCSC.DTOs;

namespace ComponentsManager.Infrastructure.Network.LCSC;

public class LCSCRepository : BaseNetRepository<LCSCPartNetDTO>
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
        INetRepository<LCSCPartNetDTO> f = this;
    }

    public override async Task<LCSCPartNetDTO?> GetPartNetAsync(string productCode)
    {
        await using Stream stream = await _httpClient
            .GetStreamAsync($"ftps/wm/product/detail?productCode={productCode}");
        LCSCRootNetDTO? lcscRootNetDto = await JsonSerializer.DeserializeAsync<LCSCRootNetDTO>(stream);
        return lcscRootNetDto?.Result;
    }
}