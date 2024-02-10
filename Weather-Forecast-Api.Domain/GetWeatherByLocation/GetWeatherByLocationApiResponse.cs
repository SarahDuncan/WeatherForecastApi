using System.Text.Json.Serialization;

namespace Weather_Forecast_Api.Domain.GetWeatherByLocation;
public class GetWeatherByLocationApiResponse
{
    [JsonPropertyName("coord")]
    public Coordinates Coordinates { get; set; }

    [JsonPropertyName("weather")]
    public IEnumerable<Weather> Weather { get; set; }

    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("main")]
    public Main Main { get; set; }

    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [JsonPropertyName("wind")]
    public Wind Wind { get; set; }

    [JsonPropertyName("clouds")]
    public Clouds Clouds { get; set; }

    [JsonPropertyName("rain")]
    public Rain Rain { get; set; }

    [JsonPropertyName("snow")]
    public Snow Snow { get; set; }

    [JsonPropertyName("dt")]
    public int TimeOfCalculation { get; set; }

    [JsonPropertyName("sys")]
    public System System { get; set; }

    [JsonPropertyName("timezone")]
    public int TimezoneInSecondsFromUTC { get; set; }

    [JsonPropertyName("id")]
    public long CityId { get; set; }

    [JsonPropertyName("name")]
    public string CityName { get; set; }

    [JsonPropertyName("cod")]
    public int CodInternalParameter { get; set; }
}

public class Coordinates
{
    [JsonPropertyName("longitude")]
    public long Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public long Latitude { get; set; }
}

public class Weather
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("main")]
    public string Main { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class Main
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public double MinTemperature { get; set; }

    [JsonPropertyName("temp_max")]
    public double MaxTemperature { get; set; }

    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; set; }

    [JsonPropertyName("grnd_level")]
    public int GroundLevel { get; set; }
}

public class Wind
{
    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    [JsonPropertyName("deg")]
    public int Degree { get; set; }

    [JsonPropertyName("gust")]
    public double Gust { get; set; }
}

public class Clouds
{
    [JsonPropertyName("all")]
    public int PercentageCloudCover { get; set; }
}

public class Rain
{
    [JsonPropertyName("1h")]
    public double LastHourVolume { get; set; }

    [JsonPropertyName("3h")]
    public double LastThreeHoursVolume { get; set; }
}

public class Snow
{
    [JsonPropertyName("1h")]
    public double LastHourVolume { get; set; }

    [JsonPropertyName("3h")]
    public double LastThreeHoursVolume { get; set; }
}

public class System
{
    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("country")]
    public string CountryCode { get; set; }

    [JsonPropertyName("sunrise")]
    public long SunriseTime { get; set; }

    [JsonPropertyName("sunset")]
    public long SunsetTime { get; set; }
}


