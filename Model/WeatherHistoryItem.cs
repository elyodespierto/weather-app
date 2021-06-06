using System;

namespace Model
{
    public class WeatherHistoryItem
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public double Temperature { get; set; }

        public double FeelsLike { get; set; }

        public DateTime Created { get; set; }

        public virtual City City { get; set; }
    }
}
