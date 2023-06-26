using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Starter
    {
        public Starter() { }
        [JsonPropertyName("id")]
        public string Id = string.Empty;

        [JsonPropertyName("name")]
        public string Name = string.Empty;

        [JsonPropertyName("home")]
        public bool? Home;

        [JsonPropertyName("battingorder")]
        public int? Battingorder;

        [JsonPropertyName("fieldingposition")]
        public int? Fieldingposition;
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