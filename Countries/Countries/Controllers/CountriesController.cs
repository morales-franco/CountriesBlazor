using System.Linq;
using System.Threading.Tasks;
using Countries.Core.Entities;
using Countries.Data;
using Countries.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //http://localhost:54854/api/countries [HTTP GET]
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _context.Countries.Include(c => c.Currency).ToListAsync();

            var countriesAsDto = countries.Select(c => new CountryListDto()
            {
                Id = c.Id,
                Name = c.Name,
                IsCool = c.IsCool,
                CurrencyName = c.Currency.Name
            }); 

            return Ok(countriesAsDto);
        }

        //http://localhost:54854/api/countries/1 [HTTP GET]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
                return NotFound();

            var countryAsDto = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name,
                IsCool = country.IsCool,
                Description = country.Description,
                BestDayToVisit = country.BestDayToVisit,
                CurrencyId = country.CurrencyId
            };


            return Ok(countryAsDto);
        }

        //http://localhost:54854/api/countries [HTTP POST] - Body { country }
        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody]CountryCreateDto model)
        {
            if (model == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newCountry = new Country()
            {
                Name = model.Name,
                Description = model.Description,
                BestDayToVisit = model.BestDayToVisit,
                IsCool = model.IsCool,
                CurrencyId = model.CurrencyId
            };

            _context.Countries.Add(newCountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountryById),
                new { id = newCountry.Id },
                model);
        }

        //http://localhost:54854/api/countries/1 [HTTP PUT] - Body { country }
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyCountry(int id, [FromBody]CountryUpdateDto country)
        {
            var countryDb = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

            if (countryDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            countryDb.Name = country.Name;
            countryDb.IsCool = country.IsCool;
            countryDb.Description = country.Description;
            countryDb.BestDayToVisit = country.BestDayToVisit;
            countryDb.CurrencyId = country.CurrencyId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //http://localhost:54854/api/countries/1 [HTTP delete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var countryDb = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

            if (countryDb == null)
                return NotFound();

            _context.Countries.Remove(countryDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}