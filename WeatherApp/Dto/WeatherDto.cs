using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{
    public class WeatherDto
    {
        public string City { get; set; }

        public string Country { get; set; }

        public double Temp { get; set; }

        public double FeelsLike { get; set; }
    }
}
