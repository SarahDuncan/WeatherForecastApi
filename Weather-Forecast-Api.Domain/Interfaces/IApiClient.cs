namespace Weather_Forecast_Api.Domain.Interfaces;
public interface IApiClient
{
    Task<TResponse> Get<TResponse>(IGetApiRequest request);
}
