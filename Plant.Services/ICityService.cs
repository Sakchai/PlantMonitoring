using Plant.Data;
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

        IPagedList<CityDTO> GetAllCities(int pageIndex = 0, int pageSize = int.MaxValue,
            string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null);

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