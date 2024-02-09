using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Weather_Forecast_Api.Api.Controllers;
using Weather_Forecast_Api.Application.Queries;
using Xunit;

namespace Weather_Forecast_Api.Api.UnitTests.Controllers;
public class WhenRequestingGet
{
    [Fact]
    public async Task ThenReturnOkResult()
    {
        var sut = SetUpControllerAndDependencies();

        var actual = await sut.Get("London");

        Assert.NotNull(actual);
        Assert.IsType<OkObjectResult>(actual);
    }

    private WeatherForecastController SetUpControllerAndDependencies()
    {
        var logger = new Mock<ILogger<WeatherForecastController>>();
        var mediator = new Mock<IMediator>();

        var queryResult = new GetWeatherByLocationQueryResult()
        {
            WeatherForLocations = new List<WeatherByLocation>
            {
                new() {
                    CityName = "London",
                    Country = "England",
                    MainWeather = "Cloudy",
                    WeatherDescription = "Partly cloudy with sprinkles of rain",
                    FeelsLike = 14
                },
                new() {
                    CityName = "Manchester",
                    Country = "England",
                    MainWeather = "Rain",
                    WeatherDescription = "Heavy showers",
                    FeelsLike = 12
                }
            }
        };

        mediator.Setup(x => x.Send(It.IsAny<GetWeatherByLocationQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(queryResult);

        return new WeatherForecastController(logger.Object, mediator.Object);
    }
}
