## Weather Forecast API 
This API consumes the public [OpenWeatherMap](https://openweathermap.org/api) API. This API **works with a web repo (currently in build) to display the weather data** it pulls through for a searched-by/specified location.
There is a swagger ui if you do not want to run the web repo.

**To run this locally you need:**
1. to add an appsettings.Development.json file and add the below code into it
2. to generate a key from [OpenWeatherMap](https://openweathermap.org/api) and replace 'your key' in the codeblock below with your key

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "OpenWeatherApiKey": "your key",
    "OpenWeatherBaseUrl": "https://api.openweathermap.org/"
  }
}
```

#### Tech stack:
- net 8
- ASP.NET Core 8
- Moq
- XUnit

TDD approach. 
