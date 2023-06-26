using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Play
    {
        public Play() { }
        [JsonPropertyName("inning")]
        public int? Inning;

        [JsonPropertyName("home")]
        public bool? Home;

        [JsonPropertyName("playerid")]
        public string Playerid = string.Empty;

        [JsonPropertyName("count")]
        public string Count = string.Empty;

        [JsonPropertyName("pitches")]
        public string Pitches = string.Empty;

        [JsonPropertyName("play")]
        public string Event = string.Empty;
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