## Weather Forecast API 
This API consumes the public [OpenWeatherMap](https://openweathermap.org/api) API. This API **works with this web repo to display the weather data** it pulls through for a searched-by/specified location.

**To run this locally you need:**
1. to generate a key from [OpenWeatherMap](https://openweathermap.org/api) and add it to your config under the key `ConnectionStrings:OpenWeatherApiKey`. I have kept my key in the appsettings.Development.json file which is in gitignore for security.
2. add the baseUrl for the API with your generated API key in the config file, under the key `ConnectionStrings:OpenWeatherBaseUrl` as that is where the code will look for it.

There is a swagger ui.

#### Tech stack:
- net 8
- ASP.NET Core 8
- Moq
- XUnit

TDD approach. 
