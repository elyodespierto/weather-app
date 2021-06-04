using System;

namespace Model
{
    public class WeatherHistoryItem
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public float Temperature { get; set; }

        public float FeelsLike { get; set; }

        public DateTime Created { get; set; }

        public virtual City City { get; set; }
    }
}
