using School.Domain.Entities;
using School.UIBlazor.Contracts;
using System.Text.Json;

namespace School.UIBlazor.Services;

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                   (await _httpClient.GetStreamAsync($"api/country/all"),
                       new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Country> GetCountryById(int contryId)
    {
        return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"api/country/{contryId}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}
