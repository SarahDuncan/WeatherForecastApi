using Weather_Forecast_Api.Domain.GetGeoCodeByLocation;
using Xunit;

namespace Weather_Forecast_Api.Domain.UnitTests.Requests;
public class WhenBuildingGetGeocodeByLocationApiRequest
{
    [Fact]
    public void Then_RequestGetUrlIsAsExpected()
    {
        var request = new GetGeocodeByLocationApiRequest("testLocation", "testKey");

        Assert.Equal("geo/1.0/direct?q=testLocation&limit=5&appid=testKey", request.GetUrl);
    }
}
