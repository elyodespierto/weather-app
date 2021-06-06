using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Dto;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private ICityRepository _cities;
        private IWeatherHistoryRepository _history;

        public WeatherController(ICityRepository cities, IWeatherHistoryRepository history)
        {
            _cities = cities;
            _history = history;
        }

        [HttpGet]
        public async Task<WeatherDto> Get(int cityId)
        {
            try
            {
                var city = _cities.GetById(cityId);
                string responseBody = null;

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?id={city.Code}&appid=7a610d481df341dc99e761ab98316b53");
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }

                var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(responseBody);

                var weatherDto = new WeatherDto
                {
                    City = city.Name,
                    Country = city.BeautyCountry,
                    Temp = Math.Round(weatherResponse.main.temp - 273.15, 2),
                    FeelsLike = Math.Round(weatherResponse.main.feels_like - 273.15, 2)
                };

                _history.SaveItem(cityId, weatherDto.Temp, weatherDto.FeelsLike);

                return weatherDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}