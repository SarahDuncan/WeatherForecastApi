using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Weather_Forecast_Api.Domain.Interfaces;

namespace Weather_Forecast_Api.Infrastructure.Api;
public class ApiClient : IApiClient
{ 
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ApiClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _httpClient.BaseAddress = new Uri(_configuration["ConnectionStrings:OpenWeatherBaseUrl"]);
    }

    public async Task<TResponse> Get<TResponse>(IGetApiRequest request)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, request.GetUrl);

        var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

        if (response.StatusCode is System.Net.HttpStatusCode.NotFound)
        {
            return default;
        }

        if (response.StatusCode is System.Net.HttpStatusCode.OK)
        {
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<TResponse>(json);
        }
        return default;
    }
}
