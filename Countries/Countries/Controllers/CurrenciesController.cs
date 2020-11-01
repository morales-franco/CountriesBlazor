using System.Linq;
using System.Threading.Tasks;
using Countries.Data;
using Countries.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //http://localhost:54854/api/currencies [HTTP GET]
        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currencies = await _context.Currencies.ToListAsync();

            var currenciesAsDto = currencies.Select(c => new CurrencyListDto()
            {
                Id = c.Id,
                Name = c.Name
            });

            return Ok(currenciesAsDto);
        }
    }
}