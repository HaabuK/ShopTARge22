using ShopTARge22.Core.Dto;
using ShopTARge22.Core.Dto.WeatherDtos;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
