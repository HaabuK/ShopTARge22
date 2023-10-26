using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;


namespace ShopTARge22.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {

        WeatherResponseRootDto IWeatherForecastServices.GetForecast(string city)
        {
            string idOpenWeather = "your password";

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={idOpenWeather}";



            return null;
        }
    }
}
