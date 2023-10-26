using System;
namespace ShopTARge22.Models.Forecast
{
	public class OpenWeatherViewModel
	{
        public string City { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double WeatherId { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Base { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }
        public double WindSpeed { get; set; }
        public int WinDeg { get; set; }
        public int CloudsAll { get; set; }
        public int Dt { get; set; }
        public int Type { get; set; }
        public int SysId { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public int TimeZone { get; set; }
        public int TimeZoneId { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}

