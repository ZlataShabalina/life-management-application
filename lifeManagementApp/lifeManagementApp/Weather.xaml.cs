using System;


namespace lifeManagementApp
{
    public partial class Weather : ContentPage
    {
        private string city;
        private readonly WeatherService _weatherService;

        public Weather()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
        }

        private void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            city = e.NewTextValue;
        }

        private async void CityClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                await DisplayAlert("Error", "Please enter a city name", "OK");
                return;
            }

            var weatherData = await _weatherService.GetWeatherDataAsync(city);

            if (weatherData != null && weatherData.results.Length > 0)
            {
                var result = weatherData.results[0];
                var latitude = result.latitude;
                var longitude = result.longitude;


                var dailyForecastData = await _weatherService.GetDailyForecastDataAsync(latitude, longitude);

                if (dailyForecastData != null && dailyForecastData.daily != null)
                {
                    var daily = dailyForecastData.daily;


                    CityLabel.Text = $"City: {result.name}";
                    CountryLabel.Text = $"Country: {result.country}";
                    MinTemperatureLabel.Text = $"{daily.temperature_2m_min[0]} °C";
                    MaxTemperatureLabel.Text = $"{daily.temperature_2m_max[0]} °C";
                    RainForecastLabel.Text = $"{daily.precipitation_sum[0]} mm";
                    WindSpeedLabel.Text = $"{daily.wind_speed_10m_max[0]} m/s";

                    CityInfoStack.IsVisible = true;
                    MinTemperatureStack.IsVisible = true;
                    MaxTemperatureStack.IsVisible = true;
                    RainForecastStack.IsVisible = true;
                    WindSpeedStack.IsVisible = true;

                    if (daily.wind_speed_10m_max[0] > 4)
                    {
                        await DisplayAlert("Wind alert", "Wonderful weather to go kite surfing!", "OK");
                        return;
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Could not fetch forecast data.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Could not fetch weather data. Try a different city.", "OK");
            }
        }
    }
}
