using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant.Data;
using Plant.Model;
using Plant.Services;

namespace Plant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/Cities
        // GET: api/Countries/?pageIndex=0&pageSize=10
        // GET: api/Countries/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc
        // GET: api/Countries/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc&filterColumn=name&filterQuery=york
        [HttpGet]
        public ActionResult<ApiResult<CountryDTO>> GetCountries(
        int pageIndex = 0,
        int pageSize = 10,
        string sortColumn = null,
        string sortOrder = null,
        string filterColumn = null,
        string filterQuery = null)
        {
            var countries = _countryService.GetAllCountries(pageIndex, pageSize, sortColumn,sortOrder,filterColumn,filterQuery);

            var data = new List<CountryDTO>();
            foreach (var c in countries)
            {
                data.Add(new CountryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    ISO2 = c.ISO2,
                    ISO3 = c.ISO3,
                    TotCities = 0
                });
            };

            return ApiResult<CountryDTO>.CreateAsync(
                    data,
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public ActionResult<Country> GetCountry(int id)
        {
            var country =  _countryService.GetCountryByID(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            var countryById = _countryService.GetCountryByID(id);
            if (countryById == null)
            {
                return NotFound();
            }
            _countryService.UpdateCountry(country);

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Country> PostCountry(Country country)
        {
            _countryService.InsertCountry(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public ActionResult<Country> DeleteCountry(int id)
        {
            var country = _countryService.GetCountryByID(id);
            if (country == null)
            {
                return NotFound();
            }
            _countryService.DeleteCountry(country);

            return country;
        }

        private bool CountryExists(int id)
        {
            return _countryService.GetCountryByID(id) != null;
        }

        [HttpPost]
        [Route("IsDupeField")]
        public bool IsDupeField(
            int countryId, 
            string fieldName, 
            string fieldValue)
        {
    
            // Dynamic approach (using System.Linq.Dynamic.Core)
            return true;
        }
    }
}
