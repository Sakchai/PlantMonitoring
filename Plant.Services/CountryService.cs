using System;
using System.Collections.Generic;
using System.Linq;
using Plant.Model;

namespace Plant.Services
{
    /// <summary>
    /// Country service
    /// </summary>
    public partial class CountryService : ICountryService
    {
        #region Fields


        private readonly IRepository<Country> _countryRepository;

        #endregion

        #region Ctor

        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        #endregion

        #region Methods


      
        /// <summary>
        /// Marks country as deleted 
        /// </summary>
        /// <param name="country">Country</param>
        public virtual void DeleteCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            

        }

        /// <summary>
        /// Inserts an country
        /// </summary>
        /// <param name="country">Country</param>
        public virtual void InsertCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            _countryRepository.Insert(country);

        }

        /// <summary>
        /// Updates the country
        /// </summary>
        /// <param name="country">Country</param>
        public virtual void UpdateCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            _countryRepository.Update(country);

        }

        public Country GetCountryByID(int id)
        {
            if (id == 0)
                return null;

            return _countryRepository.GetById(id);

        }



        public IList<Country> GetCountrysList()
        {
            var query = _countryRepository.Table;
            return query.ToList();
        }

        public IPagedList<Country> GetAllCountries(string name = null, string iso2 = null, string iso3 = null, 
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _countryRepository.Table;

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(iso2))
                query = query.Where(x => x.ISO2.Contains(iso2));

            if (!string.IsNullOrWhiteSpace(iso3))
                query = query.Where(x => x.ISO3.Contains(iso3));

            query = query.OrderBy(x => x.Name);

            var countries = new PagedList<Country>(query, pageIndex, pageSize);
            return countries;

        }



        #endregion
    }
}