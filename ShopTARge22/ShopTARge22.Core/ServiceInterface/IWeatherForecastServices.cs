using ShopTARge22.Core.Dto;


namespace ShopTARge22.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        WeatherResponseRootDto GetForecast(string city);
    }
}
