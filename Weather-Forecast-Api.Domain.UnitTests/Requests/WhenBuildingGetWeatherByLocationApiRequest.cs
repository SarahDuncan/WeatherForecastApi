using Weather_Forecast_Api.Domain.GetWeatherByLocation;
using Xunit;

namespace Weather_Forecast_Api.Domain.UnitTests.Requests;
public class WhenBuildingGetWeatherByLocationApiRequest
{
    [Fact]
    public void ThenGetUrlIsAsExpected()
    {
        var request = new GetWeatherByLocationApiRequest(78, 128, "metric", "key");

        Assert.Equal("data/2.5/weather?lat=78&lon=128&appid=key&units=metric", request.GetUrl);
    }
}
