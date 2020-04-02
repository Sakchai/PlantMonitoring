using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }


        // GET: api/Cities
        // GET: api/Cities/?pageIndex=0&pageSize=10
        // GET: api/Cities/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc
        // GET: api/Cities/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc&filterColumn=name&filterQuery=york
        [HttpGet]
        public ActionResult<ApiResult<CityDTO>> GetCitiesAsync(
                int pageIndex = 0,
                int pageSize = 10,
                string sortColumn = null,
                string sortOrder = null,
                string filterColumn = null,
                string filterQuery = null)
        {
            var cities = _cityService.GetAllCities(string.Empty, string.Empty, 0, pageIndex, pageSize, false);

            var data = new List<CityDTO>();
            foreach (var c in cities)
            {
                data.Add(new CityDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Lat = c.Latitude,
                    Lon = c.Longitude,
                    CountryId = c.CountryId,
                    CountryName = c.Country != null ? c.Country.Name : string.Empty
                });;
            };

            return ApiResult<CityDTO>.CreateAsync(
                    data,
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery); ;
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<City>> GetCity(int id)
        public ActionResult<City> GetCity(int id)
        {
            //var city = await _context.Cities.FindAsync(id);
            var city = _cityService.GetCityByID(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            var cityById = _cityService.GetCityByID(id);
            if (cityById == null)
            {
                return NotFound();
            }
            _cityService.UpdateCity(city);


            return NoContent();
        }

        // POST: api/Cities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<City> PostCity(City city)
        {
            _cityService.InsertCity(city);

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public ActionResult<City> DeleteCity(int id)
        {

            var cityById = _cityService.GetCityByID(id);
            if (cityById == null)
            {
                return NotFound();
            }

            _cityService.DeleteCity(cityById);

            return cityById;
        }

        private bool CityExists(int id)
        {
            return _cityService.GetCityByID(id) != null;
        }

        [HttpPost]
        [Route("IsDupeCity")]
        public bool IsDupeCity(City city)
        {
            return false;
        }
    }

}
