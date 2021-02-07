using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMaster.Data
{
    public class WeatherForecastService
    {
        private readonly List<WeatherForecast> _weatherForecasts;

        public WeatherForecastService(int numberOfForecasts)
        {
            if (numberOfForecasts <= 0) numberOfForecasts = 1;

            _weatherForecasts = new List<WeatherForecast>(capacity: numberOfForecasts);

            var rng = new Random();

            var runningDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1);

            for (var i = 0; i < numberOfForecasts; i++)
            {
                var tempC = rng.Next(-20, 55);

                var weatherForecast = new WeatherForecast
                {
                    Id = i + 1,
                    Date = runningDate,
                    TemperatureC = tempC,
                    Summary = WeatherSummaryHelper.ConvertFromTemperatureToSummary(tempC)
                };

                _weatherForecasts.Add(weatherForecast);

                runningDate = runningDate.AddHours(rng.Next(8, 12));
            }
        }

        public Task<List<WeatherForecast>> GetForecastsAsync() => Task.FromResult(_weatherForecasts);

        public Task<WeatherForecast?> GetForecastByIdAsync(int id) => Task.FromResult(_weatherForecasts.FirstOrDefault(f => f.Id == id));

        public Task<int> UpsertWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            WeatherForecast? matchingItem = _weatherForecasts.FirstOrDefault(f => f.Id == weatherForecast.Id);

            if (matchingItem is not null)
            {
                // Update
                matchingItem.Date = weatherForecast.Date;
                matchingItem.Summary = weatherForecast.Summary;
                matchingItem.TemperatureC = weatherForecast.TemperatureC;
                return Task.FromResult(matchingItem.Id);
            }

            // Add
            weatherForecast.Id = _weatherForecasts.Count + 1;
            _weatherForecasts.Add(weatherForecast);
            return Task.FromResult(weatherForecast.Id);
        }

        public Task DeleteWeatherForecastAsync(int id)
        {
            var item = _weatherForecasts.FirstOrDefault(f => f.Id == id);

            if (item is not null)
            {
                _weatherForecasts.Remove(item);
            }

            return Task.CompletedTask;
        }

    }
}
