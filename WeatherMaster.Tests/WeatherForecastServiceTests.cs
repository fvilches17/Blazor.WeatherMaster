using WeatherMaster.Data;
using Xunit;

namespace WeatherMaster.Tests
{
    public class WeatherForecastServiceTests
    {
        [Fact]
        public async System.Threading.Tasks.Task WeatherForecastService_Can_Get_Data_For_RangeAsync()
        {
            //given
            const int numberOfForecasts = 10;
            WeatherForecastService service = new(numberOfForecasts);

            //when
            var items = await service.GetForecastsAsync();

            //then
            Assert.Equal(numberOfForecasts, items.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task WeatherForecastService_Can_Add_Data_To_Results()
        {
            //given
            const int numberOfForecasts = 5;
            WeatherForecastService service = new(numberOfForecasts);
            WeatherForecast forecast = new();

            //when
            await service.UpsertWeatherForecastAsync(forecast);
            var items = await service.GetForecastsAsync();

            //then
            Assert.Equal(numberOfForecasts + 1, items.Count);
            Assert.Contains(forecast, items);
        }

        [Fact]
        public async System.Threading.Tasks.Task WeatherForecastService_HasMinimumForecastsOf1()
        {
            //given
            const int numberOfForecasts = -1;
            WeatherForecastService service = new(numberOfForecasts);

            //when
            var items = await service.GetForecastsAsync();

            //then
            Assert.Single(items);
        }

        [Fact]
        public async System.Threading.Tasks.Task WeatherForecastService_HasMinimumForecastsOf1_WhenZero()
        {
            //given
            const int numberOfForecasts = 0;
            WeatherForecastService service = new(numberOfForecasts);

            //when
            var items = await service.GetForecastsAsync();

            //then
            Assert.Single(items);
        }


        [Fact]
        public async System.Threading.Tasks.Task WeatherForecastService_Can_Overwrite_Data_In_Results()
        {
            //given
            const int numberOfForecasts = 9;
            WeatherForecastService service = new(numberOfForecasts);

            //when
            //we re-add the existing item
            var items = await service.GetForecastsAsync();
            WeatherForecast forecast = items[0];
            await service.UpsertWeatherForecastAsync(forecast);
            var items2 = await service.GetForecastsAsync();
            WeatherForecast forecast2 = items2[0];

            //then
            Assert.Equal(numberOfForecasts, items.Count);
            Assert.Equal(forecast.TemperatureC, forecast2.TemperatureC);
            Assert.Equal(forecast.TemperatureF, forecast2.TemperatureF);
            Assert.Equal(forecast.Summary, forecast2.Summary);
            Assert.Equal(forecast.Date, forecast2.Date);

        }

        [Fact]
        public async System.Threading.Tasks.Task WeatherForecastService_Can_Overwrite_Data_In_Results_Not_Changing_Date()
        {
            //given
            const int numberOfForecasts = 4;
            WeatherForecastService service = new(numberOfForecasts);

            //when
            var items = await service.GetForecastsAsync();
            WeatherForecast forecast = items[0];

            forecast.TemperatureC += 10;
            forecast.Summary = WeatherSummary.Hot;

            await service.UpsertWeatherForecastAsync(forecast);
            var items2 = await service.GetForecastsAsync();
            WeatherForecast forecast2 = items2[0];

            //then
            Assert.Equal(numberOfForecasts, items.Count);
            Assert.Equal(forecast.TemperatureC, forecast2.TemperatureC);
            Assert.Equal(forecast.TemperatureF, forecast2.TemperatureF);
            Assert.Equal(forecast.Summary, forecast2.Summary);
            Assert.Equal(forecast.Date, forecast2.Date);
        }
    }
}
