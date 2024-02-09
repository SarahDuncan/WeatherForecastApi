using System.Text.Json;
using Weather_Forecast_Api.Application.Services;
using Weather_Forecast_Api.Domain.GetWeatherByLocation;
using Xunit;

namespace Weather_Forecast_Api.Application.UnitTests.Services;

public class WhenMappingWeatherFromLocationService
{
    [Fact]
    public void ThenPropertiesAreMappedCorrectly()
    {
        var apiResponse = SetUpApiResponse();

        var actual = MapWeatherFromLocationService.Map(apiResponse);

        Assert.Equal(apiResponse.CityName, actual.CityName);
        Assert.Equal(apiResponse.System.CountryCode, actual.Country);
        Assert.Equal(apiResponse.Weather.First().Main, actual.MainWeather);
        Assert.Equal(apiResponse.Weather.First().Description, actual.WeatherDescription);
        Assert.Equal(apiResponse.Main.Temperature, actual.Temperature);
        Assert.Equal(apiResponse.Main.FeelsLike, actual.FeelsLike);
    }

    private GetWeatherByLocationApiResponse SetUpApiResponse()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string relativePath = Path.Combine(baseDirectory, @"TestData", @"GetWeatherByLocationApiResponseExample.json");

        using (var reader = new StreamReader(relativePath))
        {
            var json = reader.ReadToEnd();
             return JsonSerializer.Deserialize<GetWeatherByLocationApiResponse>(json);
        }
    }
}
