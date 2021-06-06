using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Dto;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/weatherHistory")]
    public class WeatherHistoryController : ControllerBase
    {
        private ICityRepository _cities;
        private IWeatherHistoryRepository _history;

        public WeatherHistoryController(ICityRepository cities, IWeatherHistoryRepository history)
        {
            _cities = cities;
            _history = history;
        }

        [HttpGet]
        public IEnumerable<WeatherHistoryItemDto> Get(int cityId)
        {
            try
            {
                var city = _cities.GetById(cityId);
                var items = _history.GetItems(cityId);

                return items.Select(x => new WeatherHistoryItemDto
                {
                    City = city.Name,
                    Country = city.BeautyCountry,
                    Temp = x.Temperature,
                    FeelsLike = x.FeelsLike
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}