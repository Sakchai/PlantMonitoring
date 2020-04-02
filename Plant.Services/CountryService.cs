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

        public IPagedList<Country> GetAllCountries(int pageIndex = 0, int pageSize = int.MaxValue, string sortColumn = null, 
            string sortOrder = null, string filterColumn = null,string filterQuery = null)
        {
            var query = _countryRepository.Table;

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
                
                if (sortColumn.Equals("iso2"))
                    if (sortOrder.Equals("asc"))
                        query = query.OrderBy(x => x.ISO2);
                    else
                        query = query.OrderByDescending(x => x.ISO2);
                
                if (sortColumn.Equals("iso3"))
                    if (sortOrder.Equals("asc"))
                        query = query.OrderBy(x => x.ISO3);
                    else
                        query = query.OrderByDescending(x => x.ISO3);
            }

            var countries = new PagedList<Country>(query, pageIndex, pageSize);
            return countries;

        }



        #endregion
    }
}