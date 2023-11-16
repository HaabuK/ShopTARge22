using System.Net;
using Nancy.Json;
using ShopTARge22.Core.Dto.WeatherDtos;
using ShopTARge22.Core.ServiceInterface;


namespace ShopTARge22.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {

        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string idOpenWeather = "8f821896d33137a9d64924972b7dd555";

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenWeather}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<WeatherResponseRootDto>(json);

                dto.City = weatherResult.Name;
                dto.Temp = weatherResult.Main.Temp;
                dto.FeelsLike = weatherResult.Main.Feels_like;
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.WindSpeed = weatherResult.Wind.Speed;
                dto.Description = weatherResult.Weather[0].Description;
                dto.Country = weatherResult.Sys.Country;
            }

            return null;
        }
    }
}
