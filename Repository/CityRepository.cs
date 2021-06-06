using Context;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CityRepository : ICityRepository
    {
        private WeatherContext _context;

        public CityRepository(WeatherContext context)
        {
            _context = context;
        }

        public void Disable(int cityId)
        {
            var city = _context.Cities.Find(cityId);

            city.Enabled = false;

            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Enable(int cityId)
        {
            var city = _context.Cities.Find(cityId);

            city.Enabled = true;

            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public City GetById(int cityId)
        {
            return _context.Cities.Find(cityId);
        }

        public IEnumerable<City> GetCities(string query)
        {
            var citiesFiltered = _context.Cities
                .Where(x => x.Name.ToLower().Contains(query.ToLower()))
                .Where(x => x.Country == "AR")
                .ToList();

            var cities = citiesFiltered.GroupBy(x => x.Name)
                .Select(x => x.FirstOrDefault())
                .ToList();

            return cities;
        }

        public IEnumerable<City> GetEnabledCities(string query)
        {
            var citiesFiltered = _context.Cities
                .Where(x => x.Name.ToLower().Contains(query.ToLower()))
                .Where(x => x.Enabled == true)
                .ToList();

            var cities = citiesFiltered.GroupBy(x => x.Name)
                .Select(x => x.FirstOrDefault())
                .ToList();

            return cities;
        }

        public IEnumerable<City> GetEnabledCities()
        {
            var citiesFiltered = _context.Cities
                .Where(x => x.Enabled == true)
                .ToList();

            var cities = citiesFiltered.GroupBy(x => x.Name)
                .Select(x => x.FirstOrDefault())
                .ToList();

            return cities;
        }
    }
}

namespace Repository.Interface
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities(string query);

        IEnumerable<City> GetEnabledCities();

        IEnumerable<City> GetEnabledCities(string query);

        City GetById(int cityId);

        void Disable(int cityId);

        void Enable(int cityId);
    }
}
