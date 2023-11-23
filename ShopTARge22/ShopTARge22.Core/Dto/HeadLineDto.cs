using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto
{
    public class HeadlineDto
    {

        [JsonPropertyName("LocalObservationDateTime")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("EpochTime")]
        public int EpockTime { get; set; }

        [JsonPropertyName("WeatherIcon")]
        public int WeatherIcon { get; set; }

        [JsonPropertyName("WeatherText")]
        public string Text { get; set; }

        [JsonPropertyName("HasPrecipitation")]
        public string Precipitation { get; set; }

        [JsonPropertyName("PrecipitationType")]
        public string PrecipType { get; set; }

        [JsonPropertyName("IsDayTime")]
        public bool Daytime { get; set; }

        [JsonPropertyName("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }
    }
}
