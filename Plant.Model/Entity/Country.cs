using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Plant.Model
{
    [Table("COUNTRY")]
    public class Country : BaseEntity
    {
        #region Constructor
        public Country()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// The unique id and primary key for this Country
        /// </summary>
        [Column("ID"), PrimaryKey, Identity]
        public override int Id { get; set; }

        /// <summary>
        /// Country name (in UTF8 format)
        /// </summary>
        [Column("NAME", Length = 40), Nullable]
        public string Name { get; set; }

        /// <summary>
        /// Country code (in ISO 3166-1 ALPHA-2 format)
        /// </summary>
        [JsonPropertyName("iso2")]
        [Column("ISO2", Length = 40), Nullable]
        public string ISO2 { get; set; }

        /// <summary>
        /// Country code (in ISO 3166-1 ALPHA-3 format)
        /// </summary>
        [JsonPropertyName("iso3")]
        [Column("ISO3", Length = 40), Nullable]
        public string ISO3 { get; set; }
        #endregion

        #region Client-side properties
        /// <summary>
        /// The number of cities related to this country.
        /// </summary>
        [NotColumn]
        public int TotCities
        {
            get
            {
                return (Cities != null)
                    ? Cities.Count
                    : _TotCities;
            }
            set { _TotCities = value; }
        }

        private int _TotCities = 0;
        #endregion

        #region Navigation Properties
        /// <summary>
        /// A list containing all the cities related to this country.
        /// </summary>
        [JsonIgnore]
        public virtual List<City> Cities { get; set; }
        #endregion
    }
}
