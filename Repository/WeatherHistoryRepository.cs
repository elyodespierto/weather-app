using Context;
using Model;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class WeatherHistoryRepository : IWeatherHistoryRepository
    {
        private WeatherContext _context;

        public WeatherHistoryRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<WeatherHistoryItem> GetItems(int cityId)
        {
            return _context.WeatherHistory
                .Where(x => x.CityId == cityId)
                .OrderByDescending(x => x.Created)
                .Take(10);
        }

        public void SaveItem(int cityId, double temp, double feelsLike)
        {
            _context.WeatherHistory.Add(new Model.WeatherHistoryItem
            {
                CityId = cityId,
                Created = System.DateTime.Now,
                Temperature = temp,
                FeelsLike = feelsLike
            });

            _context.SaveChanges();
        }
    }
}

namespace Repository.Interface
{
    public interface IWeatherHistoryRepository
    {
        public void SaveItem(int cityId, double temp, double feelsLike);

        public IEnumerable<WeatherHistoryItem> GetItems(int cityId);
    }
}