using AutoMapper;
using Plant.Data;
using Plant.Model;

namespace Plant.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<City, CityDTO>();
            CreateMap<Country, CountryDTO>();
        }
    }
}
