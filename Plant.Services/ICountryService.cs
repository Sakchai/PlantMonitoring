using Plant.Model;
using System;
using System.Collections.Generic;

namespace Plant.Services
{
    /// <summary>
    /// Country service interface
    /// </summary>
    public partial interface ICountryService
    {
        /// <summary>
        /// Gets an country by id identifier
        /// </summary>
        /// <param name="id">id identifier</param>
        /// <returns>Country</returns>

        Country GetCountryByID(int id);

        IPagedList<Country> GetAllCountries(int pageIndex = 0, int pageSize = int.MaxValue,
            string sortColumn = null, string sortOrder = null , string filterColumn = null, 
            string filterQuery = null);

        IList<Country> GetCountrysList();
        /// <summary>
        /// Marks country as deleted 
        /// </summary>
        /// <param name="country">Country</param>
        void DeleteCountry(Country country);

       

        /// <summary>
        /// Inserts an country
        /// </summary>
        /// <param name="country">Country</param>
        void InsertCountry(Country country);

        /// <summary>
        /// Updates the country
        /// </summary>
        /// <param name="country">Country</param>
        void UpdateCountry(Country country);



    }
}