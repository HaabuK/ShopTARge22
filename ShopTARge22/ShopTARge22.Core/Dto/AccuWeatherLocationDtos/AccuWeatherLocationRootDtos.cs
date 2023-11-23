using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.AccuWeatherLocationDtos
{
        public class AccuWeatherLocationRootDto
    { 
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }

        [JsonPropertyName("primaryPostalCode")]
        public string PrimaryPostalCode { get; set; }

        [JsonPropertyName("region")]
        public Region Region { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("administrativeArea")]
        public AdministrativeArea AdministrativeArea { get; set; }

        [JsonPropertyName("timeZone")]
        public TimeZone TimeZone { get; set; }

        [JsonPropertyName("geoPosition")]
        public GeoPosition GeoPosition { get; set; }

        [JsonPropertyName("isAlias")]
        public bool IsAlias { get; set; }

        [JsonPropertyName("supplementalAdminAreas")]
        public List<SupplementalAdminArea> SupplementalAdminAreas { get; set; }

        [JsonPropertyName("dataSets")]
        public List<string> DataSets { get; set; }
    }
    public class AdministrativeArea
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("localizedType")]
        public string LocalizedType { get; set; }

        [JsonPropertyName("englishType")]
        public string EnglishType { get; set; }

        [JsonPropertyName("countryID")]
        public string CountryID { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }
    }

    public class Elevation
    {
        [JsonPropertyName("metric")]
        public Metric Metric { get; set; }

        [JsonPropertyName("Imperial")]
        public Imperial imperial { get; set; }
    }

    public class GeoPosition
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("elevation")]
        public Elevation Elevation { get; set; }
    }

    public class Imperial
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("unitType")]
        public int UnitType { get; set; }
    }

    public class Metric
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("unitType")]
        public int UnitType { get; set; }
    }

    public class Region
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }
    }

    public class SupplementalAdminArea
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }
    }

    public class TimeZone
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gmtOffset")]
        public int GmtOffset { get; set; }

        [JsonPropertyName("isDaylightSaving")]
        public bool IsDaylightSaving { get; set; }

        [JsonPropertyName("nextOffsetChange")]
        public DateTime NextOffsetChange { get; set; }
    }

}
