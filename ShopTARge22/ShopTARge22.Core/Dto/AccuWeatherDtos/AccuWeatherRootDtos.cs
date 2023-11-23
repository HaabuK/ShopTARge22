using ShopTARge22.Core.Dto.AccuWeatherLocationDtos;
using ShopTARge22.Core.Dto.WeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.AccuWeatherDtos
{
    public class AccuWeatherRootDtos
    {

            [JsonPropertyName("localObservationDateTime")]
            public DateTime LocalObservationDateTime { get; set; }

            [JsonPropertyName("epochTime")]
            public int EpochTime { get; set; }

            [JsonPropertyName("weatherText")]
            public string WeatherText { get; set; }

            [JsonPropertyName("weatherIcon")]
            public int WeatherIcon { get; set; }

            [JsonPropertyName("hasPrecipitation")]
            public bool HasPrecipitation { get; set; }

            [JsonPropertyName("precipitationType")]
            public object PrecipitationType { get; set; }

            [JsonPropertyName("isDayTime")]
            public bool IsDayTime { get; set; }

            [JsonPropertyName("temperature")]
            public Temperature Temperature { get; set; }

            [JsonPropertyName("realFeelTemperature")]
            public RealFeelTemperature RealFeelTemperature { get; set; }

            [JsonPropertyName("realFeelTemperatureShade")]
            public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }

            [JsonPropertyName("relativeHumidity")]
            public int RelativeHumidity { get; set; }

            [JsonPropertyName("indoorRelativeHumidity")]
            public int IndoorRelativeHumidity { get; set; }

            [JsonPropertyName("dewPoint")]
            public DewPoint DewPoint { get; set; }

            [JsonPropertyName("wind")]
            public Wind Wind { get; set; }

            [JsonPropertyName("windGust")]
            public WindGust WindGust { get; set; }

            [JsonPropertyName("uVIndex")]
            public int UVIndex { get; set; }

            [JsonPropertyName("uVIndexText")]
            public string UVIndexText { get; set; }

            [JsonPropertyName("visibility")]
            public Visibility Visibility { get; set; }

            [JsonPropertyName("obstructionsToVisibility")]
            public string ObstructionsToVisibility { get; set; }

            [JsonPropertyName("cloudCover")]
            public int CloudCover { get; set; }

            [JsonPropertyName("ceiling")]
            public Ceiling Ceiling { get; set; }

            [JsonPropertyName("pressure")]
            public Pressure Pressure { get; set; }

            [JsonPropertyName("pressureTendency")]
            public PressureTendency PressureTendency { get; set; }

            [JsonPropertyName("past24HourTemperatureDeparture")]
            public Past24HourTemperatureDeparture Past24HourTemperatureDeparture { get; set; }

            [JsonPropertyName("apparentTemperature")]
            public ApparentTemperature ApparentTemperature { get; set; }

            [JsonPropertyName("windChillTemperature")]
            public WindChillTemperature WindChillTemperature { get; set; }

            [JsonPropertyName("wetBulbTemperature")]
            public WetBulbTemperature WetBulbTemperature { get; set; }

            [JsonPropertyName("precip1hr")]
            public Precip1hr Precip1hr { get; set; }

            [JsonPropertyName("temperatureSummary")]
            public TemperatureSummary TemperatureSummary { get; set; }

            [JsonPropertyName("mobileLink")]
            public string MobileLink { get; set; }

            [JsonPropertyName("link")]
            public string Link { get; set; }
    }

        public class ApparentTemperature
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Ceiling
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class DewPoint
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Direction
        {
            [JsonPropertyName("degrees")]
            public int Degrees { get; set; }

            [JsonPropertyName("localized")]
            public string Localized { get; set; }

            [JsonPropertyName("english")]
            public string English { get; set; }
        }

        public class Imperial
        {
            [JsonPropertyName("value")]
            public int Value { get; set; }

            [JsonPropertyName("unit")]
            public string Unit { get; set; }

            [JsonPropertyName("unitType")]
            public int UnitType { get; set; }

            [JsonPropertyName("phrase")]
            public string Phrase { get; set; }
        }

        public class Maximum
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Metric
        {
            [JsonPropertyName("value")]
            public double Value { get; set; }

            [JsonPropertyName("unit")]
            public string Unit { get; set; }

            [JsonPropertyName("unitType")]
            public int UnitType { get; set; }

            [JsonPropertyName("phrase")]
            public string Phrase { get; set; }
        }

        public class Minimum
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Past12HourRange
        {
            [JsonPropertyName("minimum")]
            public Minimum Minimum { get; set; }

            [JsonPropertyName("maximum")]
            public Maximum Maximum { get; set; }
        }

        public class Past12Hours
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Past18Hours
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Past24HourRange
        {
            [JsonPropertyName("minimum")]
            public Minimum Minimum { get; set; }

            [JsonPropertyName("maximum")]
            public Maximum Maximum { get; set; }
        }

        public class Past24Hours
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Past24HourTemperatureDeparture
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Past3Hours
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Past6HourRange
        {
            [JsonPropertyName("minimum")]
            public Minimum Minimum { get; set; }

            [JsonPropertyName("maximum")]
            public Maximum Maximum { get; set; }
        }

        public class Past6Hours
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Past9Hours
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class PastHour
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Precip1hr
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Precipitation
        {
            [JsonPropertyName("metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Pressure
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class PressureTendency
        {
            [JsonPropertyName("LocalizedText")]
            public string LocalizedText { get; set; }

            [JsonPropertyName("Code")]
            public string Code { get; set; }
        }

        public class RealFeelTemperature
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class RealFeelTemperatureShade
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Speed
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Temperature
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class TemperatureSummary
        {
            [JsonPropertyName("Past6HourRange")]
            public Past6HourRange Past6HourRange { get; set; }

            [JsonPropertyName("Past12HourRange")]
            public Past12HourRange Past12HourRange { get; set; }

            [JsonPropertyName("Past24HourRange")]
            public Past24HourRange Past24HourRange { get; set; }
        }

        public class Visibility
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class WetBulbTemperature
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class Wind
        {
            [JsonPropertyName("Direction")]
            public Direction Direction { get; set; }

            [JsonPropertyName("Speed")]
            public Speed Speed { get; set; }
        }

        public class WindChillTemperature
        {
            [JsonPropertyName("Metric")]
            public Metric Metric { get; set; }

            [JsonPropertyName("Imperial")]
            public Imperial Imperial { get; set; }
        }

        public class WindGust
        {
            [JsonPropertyName("Speed")]
            public Speed Speed { get; set; }
        }

    
}

