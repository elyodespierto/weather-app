using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
    }

    public class WeatherResponse
    {
        public Main main { get; set; }
    }
}
