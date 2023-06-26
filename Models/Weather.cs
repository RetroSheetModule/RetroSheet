using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Weather
    {
        public Weather() { }
        [JsonPropertyName("temp")]
        public int? Temp;

        [JsonPropertyName("winddir")]
        public string Winddir = string.Empty;

        [JsonPropertyName("windspeed")]
        public int? Windspeed;

        [JsonPropertyName("fieldcond")]
        public string FieldCond = string.Empty;

        [JsonPropertyName("sky")]
        public string Sky = string.Empty;
        public override string ToString()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}