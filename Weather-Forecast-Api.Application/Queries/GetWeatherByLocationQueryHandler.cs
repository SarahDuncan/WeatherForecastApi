using MediatR;
using Microsoft.Extensions.Configuration;
using Weather_Forecast_Api.Application.Services;
using Weather_Forecast_Api.Domain.GetGeoCodeByLocation;
using Weather_Forecast_Api.Domain.GetWeatherByLocation;
using Weather_Forecast_Api.Domain.Interfaces;

namespace Weather_Forecast_Api.Application.Queries;
public class GetWeatherByLocationQueryHandler : IRequestHandler<GetWeatherByLocationQuery, GetWeatherByLocationQueryResult>
{
    private readonly IApiClient _apiClient;
    private readonly IConfiguration _configuration;

    public GetWeatherByLocationQueryHandler(IApiClient apiClient, IConfiguration configuration)
    {
        _apiClient = apiClient;
        _configuration = configuration;
    }

    public async Task<GetWeatherByLocationQueryResult> Handle(GetWeatherByLocationQuery request, CancellationToken cancellationToken)
    {
        var keyValue = _configuration["ConnectionStrings:OpenWeatherApiKey"];
        var locationGeocode = await _apiClient.Get<List<GetGeocodeByLocationApiResponse>>(new GetGeocodeByLocationApiRequest(request.Location, keyValue));

        var locationsResponses = new GetWeatherByLocationQueryResult() { WeatherForLocations = [] };
        foreach (var location in locationGeocode)
        {
            var response = await _apiClient.Get<GetWeatherByLocationApiResponse>(new GetWeatherByLocationApiRequest(location.Latitude, location.Longitude, "metric", keyValue));
            var responseAsResult = MapWeatherFromLocationService.Map(response);
            locationsResponses.WeatherForLocations.Add(responseAsResult);
        }

        return locationsResponses;
    }
}
