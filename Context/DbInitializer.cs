using Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Context
{
    public class JsonCity
    {
        public float id { get; set; }

        public string name { get; set; }

        public string country { get; set; }
    }

    public static class DbInitializer
    {
        public static void Initialize(WeatherContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cities.Any())
            {
                return;   // DB has been seeded
            }

            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var path = Path.Combine(basePath, "Resources", "city.list.json").Replace("\\", "/");

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                var jsoncities = JsonSerializer.Deserialize<List<JsonCity>>(json);

                var items = jsoncities.Select(x => new City
                {
                    Code = x.id.ToString(),
                    Country = x.country,
                    Name = x.name,
                    Enabled = false
                });

                context.Cities.AddRange(items);

                context.SaveChanges();
            }
        }
    }
}