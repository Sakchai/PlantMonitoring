using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant.Model
{
    [Table("CITY")]
    public class City : BaseEntity
    {
        #region Constructor

        #endregion

        #region Properties
        /// <summary>
        /// The unique id and primary key for this City
        /// </summary>
        [Column("ID"), PrimaryKey, Identity]
        public override int Id { get; set; }

        /// <summary>
        /// City name (in UTF8 format)
        /// </summary>
        [Column("Name", Length = 40), Nullable]
        public string Name { get; set; }

        /// <summary>
        /// City name (in ASCII format)
        /// </summary>
        [Column("NAME_ASCII", Length = 40), Nullable]
        public string Name_ASCII { get; set; }

        /// <summary>
        /// City latitude
        /// </summary>
        [Column("LAT",DbType = "decimal(7,4)"), NotNull]
        public decimal Latitude { get; set; }

        /// <summary>
        /// City longitude
        /// </summary>
        [Column("LON",DbType = "decimal(7,4)"), NotNull]
        public decimal Longitude { get; set; }

        /// <summary>
        /// Country Id (foreign key)
        /// </summary>
        [Column("COUNTRYID"), NotNull]
        public int CountryId { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// The country related to this city.
        /// </summary>
        public virtual Country Country { get; set; }
        #endregion
    }
}
