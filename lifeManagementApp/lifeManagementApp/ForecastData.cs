using System;

namespace lifeManagementApp
{
    public class ForecastData
    {
        public Daily daily { get; set; }

        public class Daily
        {
            public float[] temperature_2m_min { get; set; }
            public float[] temperature_2m_max { get; set; }
            public float[] precipitation_sum { get; set; }
            public float[] wind_speed_10m_max { get; set; }
        }
    }
}
