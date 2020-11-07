using Countries.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Countries.App.Interfaces
{
    public interface ICountryService
    {
        Task AddCountry(CountryCreateDto country);
        Task DeleteCountry(int countryId);
        Task<IEnumerable<CountryListDto>> GetAllCountries();
        Task<CountryDto> GetCountryById(int countryId);
        Task UpdateCountry(int countryId, CountryUpdateDto country);
    }
}
