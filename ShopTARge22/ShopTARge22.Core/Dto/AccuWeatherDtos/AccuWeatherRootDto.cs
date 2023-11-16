using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopTARge22.Core.Dto.DailyForecastDto;

namespace ShopTARge22.Core.Dto
{
    public class AccuWeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastDto> DailyForecasts { get; set; }
    }
}
