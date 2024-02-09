using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather_Forecast_Api.Application.Queries;

namespace Weather_Forecast_Api.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{location}")]
    public async Task<IActionResult> Get([FromRoute] string location)
    {
        var result = await _mediator.Send(new GetWeatherByLocationQuery { Location = location });
        return Ok(result);
    }
}
