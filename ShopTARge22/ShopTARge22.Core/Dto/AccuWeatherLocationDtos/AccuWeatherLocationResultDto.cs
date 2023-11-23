using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Core.Dto.AccuWeatherLocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.AccuWeatherLocationDtos
{
    public class AccuWeatherLocationResultDto
    {
        public string City {  get; set; }
        public int Version { get; set; }

        public string Key { get; set; }

        public string Type { get; set; }

        public int Rank { get; set; }

        public string LocalizedName { get; set; }

        public string EnglishName { get; set; }

        public string PrimaryPostalCode { get; set; }

        public Region Region { get; set; }

        public Country Country { get; set; }

        public AdministrativeArea AdministrativeArea { get; set; }

        public TimeZone TimeZone { get; set; }

        public GeoPosition GeoPosition { get; set; }

        public bool IsAlias { get; set; }

        public List<SupplementalAdminArea> SupplementalAdminAreas { get; set; }

        public List<string> DataSets { get; set; }
    }

}
