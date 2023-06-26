using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Event
    {
        public Event()
        {
            Game = new Game();
        }
        public Event(string id)
        {
            this.Id = id;
            Game = new Game();
        }
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("version")]
        public int? Version = 2;

        [JsonPropertyName("game")]
        public Game? Game;
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