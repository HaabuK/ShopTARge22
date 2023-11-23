using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.AccuWeatherDtos
{
    public class AccuWeatherResultDtos
    {
        public string City { get; set; }
        public double Temperature { get; set; }
        public double RealFeelTemperature { get; set; }
        public double RelativeHumidity { get; set; }
        public double Wind {  get; set; }
        public double Pressure { get; set; }
        public string WeatherText { get; set; }

    }
}
