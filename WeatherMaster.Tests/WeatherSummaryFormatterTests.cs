using WeatherMaster.Data;
using Xunit;

namespace WeatherMaster.Tests
{
    public class WeatherSummaryFormatterTests
    {
        [Fact]
        public void TestWeatherSummaryFormatter_CanFormatKnownValue()
        {
            //Given
            const WeatherSummary summary = WeatherSummary.Hot;

            //Act
            string value = WeatherSummaryHelper.DisplayName(summary);

            //Assert
            Assert.Equal("Hot", value);
        }

        [Fact]
        public void TestWeatherSummaryFormatter_CanFormatUnknownValue()
        {
            //Given
            const WeatherSummary summary = (WeatherSummary)120;

            //Act
            string value = WeatherSummaryHelper.DisplayName(summary);

            //Assert
            Assert.Equal("Invalid", value);
        }
    }
}
