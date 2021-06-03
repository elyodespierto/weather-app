using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public static class DbInitializer
    {
        public static void Initialize(WeatherContext context)
        {
            context.Database.EnsureCreated();

            //if (context.WeatherHistory.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var items = new WeatherHistoryItem[]
            //{
            //    new WeatherHistoryItem
            //    {
            //        Temperature = 2
            //    }
            //};

            //foreach (var s in items)
            //{
            //    context.WeatherHistory.Add(s);
            //}

            //context.SaveChanges();
        }
    }
}
