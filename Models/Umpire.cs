using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Umpire
    {
        public Umpire() { }
        [JsonPropertyName("umphome")]
        public string Umphome = string.Empty;

        [JsonPropertyName("ump1b")]
        public string Ump1b = string.Empty;

        [JsonPropertyName("ump2b")]
        public string Ump2b = string.Empty;

        [JsonPropertyName("ump3b")]
        public string Ump3b = string.Empty;

        [JsonPropertyName("umplf")]
        public object Umplf = string.Empty;

        [JsonPropertyName("umprf")]
        public object Umprf = string.Empty;
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