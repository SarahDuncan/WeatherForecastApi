namespace Weather_Forecast_Api.Application.Queries;
public class GetWeatherByLocationQueryResult
{
    public List<WeatherByLocation> WeatherForLocations { get; set; }
}

public class WeatherByLocation 
{
    public string CityName { get; set; }
    public string Country { get; set; }
    public string MainWeather { get; set; }
    public string WeatherDescription { get; set; }
    public double Temperature { get; set; }
    public double FeelsLike { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

