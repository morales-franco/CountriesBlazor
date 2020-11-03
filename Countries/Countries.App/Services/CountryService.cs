using Countries.App.Interfaces;
using Countries.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Countries.App.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryListDto>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<List<CountryListDto>>
                (await _httpClient.GetStreamAsync($"api/countries"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
