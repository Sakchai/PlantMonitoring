using System;
using System.Collections.Generic;
using System.Linq;
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

        public IPagedList<City> GetAllCities(string Name = null, string countryName = null, int countryId = 0, 
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _cityRepository.Table;
            if (!string.IsNullOrWhiteSpace(Name))
                query = query.Where(a => a.Name.Contains(Name));

            if (countryId != 0)
                query = query.Where(a => a.CountryId == countryId);

            if (!string.IsNullOrWhiteSpace(countryName))
                query = from cty in query
                                join cn in _countryRepository.Table on cty.CountryId equals cn.Id
                                where cn.Name.Contains(countryName)
                                select cty;
            query = query.OrderBy(x => x.Name);
            var cities = new PagedList<City>(query, pageIndex, pageSize);
            return cities;
        }



        #endregion
    }
}