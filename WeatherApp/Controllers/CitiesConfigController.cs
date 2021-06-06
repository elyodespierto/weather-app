using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Dto;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/citiesConfig")]
    public class CitiesConfigController : ControllerBase
    {
        private ICityRepository _cities;

        public CitiesConfigController(ICityRepository cities)
        {
            _cities = cities;
        }

        [HttpGet]
        public IEnumerable<CityConfigDto> Get()
        {
            return _cities.GetEnabledCities().Select(x => new CityConfigDto
            {
                Name = x.Name,
                Country = x.BeautyCountry
            });
        }

        [HttpDelete]
        public void Delete(int cityId)
        {
            _cities.Disable(cityId);
        }

        [HttpPost]
        public void Post([FromBody]CityConfigRequest city)
        {
            _cities.Enable(city.CityId);
        }
    }
}