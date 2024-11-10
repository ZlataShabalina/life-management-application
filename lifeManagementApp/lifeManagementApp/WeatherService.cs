using System;
using System.Net.Http;
using System.Threading.Tasks;
using lifeManagementApp;
using Newtonsoft.Json;

namespace lifeManagementApp
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string GeocodingUrl = "https://geocoding-api.open-meteo.com/v1/search";
        private const string WeatherForecastUrl = "https://api.open-meteo.com/v1/forecast";

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData.WeatherRootobject> GetWeatherDataAsync(string city)
        {
            var url = $"{GeocodingUrl}?name={city}&count=1&format=json";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherData.WeatherRootobject>(jsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
                return null;
            }
        }

        public async Task<ForecastData> GetDailyForecastDataAsync(float latitude, float longitude)
        {
            var url = $"{WeatherForecastUrl}?latitude={latitude}&longitude={longitude}&daily=temperature_2m_min,temperature_2m_max,precipitation_sum,wind_speed_10m_max&timezone=auto&wind_speed_unit=ms";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResult = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Forecast API Response: " + jsonResult);

                return JsonConvert.DeserializeObject<ForecastData>(jsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching forecast data: {ex.Message}");
                return null;
            }
        }

    }
}