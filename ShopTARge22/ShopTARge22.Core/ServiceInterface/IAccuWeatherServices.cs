using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Core.Dto.AccuWeatherLocationDtos;
using ShopTARge22.Core.Dto.WeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IAccuWeatherServices
    {
        Task<AccuWeatherLocationResultDto> AccuWeatherGet(AccuWeatherLocationResultDto dto1);
        Task<AccuWeatherResultDtos>AccuWeatherResult(AccuWeatherResultDtos dto, AccuWeatherLocationResultDto dto1);
    }
}
