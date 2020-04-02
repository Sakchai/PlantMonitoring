using System;
using System.Collections.Generic;
using System.Linq;
using Plant.Data;
using Plant.Model;

namespace Plant.Services
{
    /// <summary>
    /// City service
    /// </summary>
    public partial class CityService : ICityService
    {
        #region Fields


        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Country> _countryRepository;

        #endregion

        #region Ctor

        public CityService(IRepository<City> cityRepository, IRepository<Country> countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        #endregion

        #region Methods


      
        /// <summary>
        /// Marks city as deleted 
        /// </summary>
        /// <param name="city">City</param>
        public virtual void DeleteCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));

            

        }

        /// <summary>
        /// Inserts an city
        /// </summary>
        /// <param name="city">City</param>
        public virtual void InsertCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));

            _cityRepository.Insert(city);

        }

        /// <summary>
        /// Updates the city
        /// </summary>
        /// <param name="city">City</param>
        public virtual void UpdateCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));

            _cityRepository.Update(city);

        }

        public City GetCityByID(int id)
        {
            if (id == 0)
                return null;

            return _cityRepository.GetById(id);

        }



        public IList<City> GetCitysList()
        {
            var query = _cityRepository.Table;
            return query.ToList();
        }

        public IPagedList<CityDTO> GetAllCities(int pageIndex = 0, int pageSize = int.MaxValue, 
            string sortColumn = null,string sortOrder = null,string filterColumn = null,string filterQuery = null)
        {
            var query = _cityRepository.Table;

            if (!string.IsNullOrWhiteSpace(filterColumn) && (!string.IsNullOrWhiteSpace(filterQuery)))
            {
                if (filterColumn.Equals("name"))
                    query = query.Where(x => x.Name.Contains(filterQuery));
            }

            if (!string.IsNullOrWhiteSpace(sortColumn) && (!string.IsNullOrWhiteSpace(sortOrder)))
            {
                if (sortColumn.Equals("name"))
                    if (sortOrder.Equals("asc"))
                        query = query.OrderBy(x => x.Name);
                    else
                        query = query.OrderByDescending(x => x.Name);

            }
            var cityDTOs = query.Select(x => new CityDTO
            {
                Id = x.Id,
                CountryId = x.CountryId,
                CountryName = _countryRepository.GetById(x.CountryId).Name,
                Lat = x.Latitude,
                Lon = x.Longitude,
                Name = x.Name,
                Name_ASCII = x.Name_ASCII
            });
            var cities = new PagedList<CityDTO>(cityDTOs, pageIndex, pageSize);
            return cities;
        }



        #endregion
    }
}