using MediatR;
using Weather_Forecast_Api.Domain.Interfaces;
using Weather_Forecast_Api.Infrastructure.Api;

namespace Weather_Forecast_Api.Api.AppStart;

public static class AddServiceRegistrationExtension
{
    public static void AddServiceRegistration(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped(typeof(IApiClient), typeof(ApiClient));
        services.AddTransient<IApiClient, ApiClient>();
    }
}
