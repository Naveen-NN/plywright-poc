
namespace Models
{
    using System.Text.Json.Serialization;
    public class Geo
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; }
        [JsonPropertyName("lng")]
        public string Lng { get; set; }
    }

}