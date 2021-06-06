using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Dto;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        private ICityRepository _cities;

        public CityController(ICityRepository cities)
        {
            _cities = cities;
        }

        [HttpGet]
        public IEnumerable<CityDto> Get(string q)
        {
            return _cities.GetCities(q).Select(x => new CityDto
            {
                Id = x.Id.ToString(),
                Text = x.Name
            });
        }

        [HttpGet]
        [Route("enabled")]
        public IEnumerable<CityDto> GetEnabled(string q)
        {
            return _cities.GetEnabledCities(q).Select(x => new CityDto
            {
                Id = x.Id.ToString(),
                Text = x.Name
            });
        }
    }
}