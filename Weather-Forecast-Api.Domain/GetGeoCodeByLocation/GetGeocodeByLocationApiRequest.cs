using Weather_Forecast_Api.Domain.Interfaces;

namespace Weather_Forecast_Api.Domain.GetGeoCodeByLocation;
public class GetGeocodeByLocationApiRequest : IGetApiRequest
{
    private string _location;
    private string _key;

    public GetGeocodeByLocationApiRequest(string location, string key)
    {
        _location = location;  
        _key = key;
    }
    public string GetUrl => $"geo/1.0/direct?q={_location}&limit=5&appid={_key}";
}
