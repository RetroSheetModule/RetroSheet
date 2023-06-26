using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Game
    {
        public Game()
        {
            Info = new Info();
            Starters = new List<Starter>();
            Subs = new List<Sub>();
            Plays = new List<Play>();
            Data = new List<Datum>();
        }
        [JsonPropertyName("info")]
        public Info? Info;

        [JsonPropertyName("starters")]
        public List<Starter>? Starters;

        [JsonPropertyName("subs")]
        public List<Sub>? Subs;

        [JsonPropertyName("plays")]
        public List<Play>? Plays;

        [JsonPropertyName("data")]
        public List<Datum>? Data;
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