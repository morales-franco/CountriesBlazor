using Countries.App.Interfaces;
using Countries.Shared.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Countries.App.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CurrencyListDto>> GetAllCurrencies()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CurrencyListDto>>
                (await _httpClient.GetStreamAsync($"api/currencies"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
