using System;
using System.Text.Json.Serialization;


namespace ShopTARge22.Core.Dto.Norris
{
    public class ChuckNorrisRootDto
    {
        [JsonPropertyName("categories")]
        public List<object> Categories { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("icon_url")]
        public string Icon_url { get; set; }

        [JsonPropertyName("icon_url")]
        public string Url { get; set; }

        [JsonPropertyName("icon_url")]
        public string Value { get; set; }
    }
}
