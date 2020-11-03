using Countries.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Countries.App.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryListDto>> GetAllCountries();
    }
}
