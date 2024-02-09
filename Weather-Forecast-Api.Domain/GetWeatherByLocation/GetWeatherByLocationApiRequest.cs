using Weather_Forecast_Api.Domain.Interfaces;

namespace Weather_Forecast_Api.Domain.GetWeatherByLocation;
public class GetWeatherByLocationApiRequest : IGetApiRequest
{
    private string _key;
    private float _latitude;
    private float _longitude;
    private string _units;

    public GetWeatherByLocationApiRequest(float latitude, float longitude, string units, string key)
    {
        _latitude = latitude;
        _longitude = longitude;
        _units = units;
        _key = key;
    }

    public string GetUrl => $"data/2.5/weather?lat={_latitude}&lon={_longitude}&appid={_key}&units={_units}";
}
