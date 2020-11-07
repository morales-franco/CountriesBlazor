using Countries.App.Interfaces;
using Countries.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task<IEnumerable<CountryListDto>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CountryListDto>>
                (await _httpClient.GetStreamAsync($"api/countries"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<CountryDto> GetCountryById(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<CountryDto>
                (await _httpClient.GetStreamAsync($"api/countries/{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddCountry(CountryCreateDto country)
        {
            var countryAsJson =
                new StringContent(JsonSerializer.Serialize(country), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/countries", countryAsJson);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error in server - Please contact your administrator");
        }

        public async Task UpdateCountry(int countryId, CountryUpdateDto country)
        {
            var countryAsJson =
                new StringContent(JsonSerializer.Serialize(country), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/countries/{ countryId }", countryAsJson);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error in server - Please contact your administrator");

        }

        public async Task DeleteCountry(int countryId)
        {
            var response = await _httpClient.DeleteAsync($"api/countries/{countryId}");

            if (!response.IsSuccessStatusCode)
            {
                var serverErrorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(serverErrorMessage);
            }
                
        }
    }
}
