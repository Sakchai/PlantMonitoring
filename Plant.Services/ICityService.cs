using Plant.Model;
using System;
using System.Collections.Generic;

namespace Plant.Services
{
    /// <summary>
    /// City service interface
    /// </summary>
    public partial interface ICityService
    {
        /// <summary>
        /// Gets an city by id identifier
        /// </summary>
        /// <param name="id">id identifier</param>
        /// <returns>City</returns>

        City GetCityByID(int id);

        IPagedList<City> GetAllCities(string Name = null,string countryName = null,
            int countryId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue,
            bool showHidden = false);

        IList<City> GetCitysList();
        /// <summary>
        /// Marks city as deleted 
        /// </summary>
        /// <param name="city">City</param>
        void DeleteCity(City city);

       

        /// <summary>
        /// Inserts an city
        /// </summary>
        /// <param name="city">City</param>
        void InsertCity(City city);

        /// <summary>
        /// Updates the city
        /// </summary>
        /// <param name="city">City</param>
        void UpdateCity(City city);



    }
}