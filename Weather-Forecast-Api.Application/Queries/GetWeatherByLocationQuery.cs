using MediatR;

namespace Weather_Forecast_Api.Application.Queries;
public class GetWeatherByLocationQuery : IRequest<GetWeatherByLocationQueryResult>
{
    public string Location { get; set; } = null!;
}
