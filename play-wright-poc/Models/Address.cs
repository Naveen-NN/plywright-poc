namespace Models
{
    using System.Text.Json.Serialization;
    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("suite")]
        public string Suite { get; set; }
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }
        [JsonPropertyName("geo")]
        public Geo Geo { get; set;}
        
    }
}