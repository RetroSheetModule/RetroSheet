using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Datum
    {
        public Datum() { }
        [JsonPropertyName("id")]
        public string Id = string.Empty;

        [JsonPropertyName("playerid")]
        public string Playerid = string.Empty;

        [JsonPropertyName("runsallowed")]
        public int? Runsallowed;
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