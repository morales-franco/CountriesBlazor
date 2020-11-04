using System.Collections.Generic;
using System.Threading.Tasks;

namespace Countries.App.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Countries.Shared.Dtos.CurrencyListDto>> GetAllCurrencies();
    }
}
