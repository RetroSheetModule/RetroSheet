using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Sub
    {
        [JsonPropertyName("playerid")]
        public string Playerid = string.Empty;

        [JsonPropertyName("playername")]
        public string PlayerName = string.Empty;

        [JsonPropertyName("home")]
        public int? Home;

        [JsonPropertyName("battingorder")]
        public int? BattingOrder;

        [JsonPropertyName("fieldingposition")]
        public int? FieldingPosition;
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