namespace Models
{

    using System.Text.Json.Serialization;
    public class Company
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonPropertyName("bs")]
        public string  BS { get; set; }
    }
}