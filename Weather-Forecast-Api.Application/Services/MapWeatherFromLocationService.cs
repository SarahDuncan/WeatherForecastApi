using Weather_Forecast_Api.Application.Queries;
using Weather_Forecast_Api.Domain.GetWeatherByLocation;

namespace Weather_Forecast_Api.Application.Services;
public static class MapWeatherFromLocationService
{
    public static WeatherByLocation Map(GetWeatherByLocationApiResponse source)
    {
        return new WeatherByLocation
        {
            CityName = source.CityName,
            Country = source.System.CountryCode,
            MainWeather = source.Weather.First().Main,
            WeatherDescription = source.Weather.First().Description,
            Temperature = source.Main.Temperature,
            FeelsLike = source.Main.FeelsLike,
            Latitude = source.Coordinates.Latitude,
            Longitude = source.Coordinates.Longitude
        };
    }
}
