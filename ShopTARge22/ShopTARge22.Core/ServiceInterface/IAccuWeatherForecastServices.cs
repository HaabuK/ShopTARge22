using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IAccuWeatherForecastServices
    {
        Task<AccuWeatherResultDto> WeatherDetail(AccuWeatherResultDto dto);

        //Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto);
    }
}
