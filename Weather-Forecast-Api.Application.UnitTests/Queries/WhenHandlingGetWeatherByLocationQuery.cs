using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using Weather_Forecast_Api.Application.Queries;
using Weather_Forecast_Api.Domain.GetGeoCodeByLocation;
using Weather_Forecast_Api.Domain.GetWeatherByLocation;
using Weather_Forecast_Api.Domain.Interfaces;
using Xunit;

namespace Weather_Forecast_Api.Application.UnitTests.Queries;
public class WhenHandlingGetWeatherByLocationQuery
{
    [Fact]
    public async Task Then_QueryResponseIsReturned()
    {
        var sut = await SetupSutWithDependencies();
        var query = SetupQuery();

        var actual = await sut.Handle(query, CancellationToken.None);

        Assert.NotNull(actual);
        Assert.IsType<GetWeatherByLocationQueryResult>(actual);
        Assert.Equal(5, actual.WeatherForLocations.Count);
    }

    private async Task<GetWeatherByLocationQueryHandler> SetupSutWithDependencies()
    {
        var mediator = new Mock<IMediator>();
        var apiClient = new Mock<IApiClient>();
        var configuration = new Mock<IConfiguration>();

        var getGeocodeByLocationApiResponse = SetupGeocodeByLocationApiResponse();
        var getWeatherByLocationApiResponse = SetupWeatherByLocationApiResponse();

        apiClient.Setup(x => x.Get<List<GetGeocodeByLocationApiResponse>>(It.IsAny<GetGeocodeByLocationApiRequest>())).ReturnsAsync(getGeocodeByLocationApiResponse);
        apiClient.Setup(x => x.Get<GetWeatherByLocationApiResponse>(It.IsAny<GetWeatherByLocationApiRequest>())).ReturnsAsync(getWeatherByLocationApiResponse);

        var sut = new GetWeatherByLocationQueryHandler(apiClient.Object, configuration.Object);

        return sut;
    }

    private List<GetGeocodeByLocationApiResponse> SetupGeocodeByLocationApiResponse()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string relativePath = Path.Combine(baseDirectory, @"TestData", @"GetGeocodeByLocationApiResponseExample.json");

        using (var reader = new StreamReader(relativePath))
        {
            var json = reader.ReadToEnd();
            var result = JsonSerializer.Deserialize<List<GetGeocodeByLocationApiResponse>>(json);
            return result;
        }
    }

    private GetWeatherByLocationApiResponse SetupWeatherByLocationApiResponse()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string relativePath = Path.Combine(baseDirectory, @"TestData", @"GetWeatherByLocationApiResponseExample.json");

        using (var reader = new StreamReader(relativePath))
        {
            var json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<GetWeatherByLocationApiResponse>(json);
        }
    }

    private GetWeatherByLocationQuery SetupQuery()
    {
        return new GetWeatherByLocationQuery() { Location = "London" };
    }
}
