namespace WeatherMaster.Data
{
    public class WeatherSummaryHelper
    {
        public static string DisplayName(WeatherSummary summary) => summary switch
        {
            WeatherSummary.Freezing => "Freezing",
            WeatherSummary.Chilly => "Chilly",
            WeatherSummary.Cool => "Cool",
            WeatherSummary.Mild => "Mild",
            WeatherSummary.Warm => "Warm",
            WeatherSummary.Hot => "Hot",
            WeatherSummary.Scorching => "Scorching",
            _ => "Invalid"
        };

        public static string EmojiName(WeatherSummary summary) => summary switch
        {
            WeatherSummary.Freezing => "🥶",
            WeatherSummary.Chilly => "🧊",
            WeatherSummary.Cool => "❄️",
            WeatherSummary.Mild => "⛅",
            WeatherSummary.Warm => "☀️",
            WeatherSummary.Hot => "🔆",
            WeatherSummary.Scorching => "🥵",
            _ => "-"
        };

        public static WeatherSummary ConvertFromTemperatureToSummary(int temperature) => temperature switch
        {
            <= 0 => WeatherSummary.Freezing,
            > 0 and < 10 => WeatherSummary.Chilly,
            >= 10 and < 15 => WeatherSummary.Cool,
            >= 15 and < 20 => WeatherSummary.Mild,
            >= 20 and < 25 => WeatherSummary.Warm,
            >= 25 and < 30 => WeatherSummary.Hot,
            >= 30 => WeatherSummary.Scorching
        };
    }
}
