using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetroSheet.V2.Models
{
    public class Info
    {
        public Info() { }
        [JsonPropertyName("visitingteam")]
        public string VisitingTeam = string.Empty;

        [JsonPropertyName("hometeam")]
        public string HomeTeam = string.Empty;

        [JsonPropertyName("site")]
        public string Site = string.Empty;

        [JsonPropertyName("date")]
        public DateTime Date;

        [JsonPropertyName("number")]
        public int? Number;

        [JsonPropertyName("starttime")]
        public string StartTime = string.Empty;

        [JsonPropertyName("daynight")]
        public string DayNight = string.Empty;

        [JsonPropertyName("innings")]
        public int? Innings;

        [JsonPropertyName("tiebreaker")]
        public int? Tiebreaker;

        [JsonPropertyName("useddh")]
        public bool? UsedDh;

        [JsonPropertyName("umpires")]
        public Umpire? Umpires;

        [JsonPropertyName("inputtime")]
        public DateTime InputTime;

        [JsonPropertyName("howscored")]
        public string HowScored = string.Empty;

        [JsonPropertyName("pitches")]
        public string Pitches = string.Empty;

        [JsonPropertyName("oscorer")]
        public string Oscorer = string.Empty;

        [JsonPropertyName("weather")]
        public Weather? Weather;

        [JsonPropertyName("timeofgame")]
        public int? TimeOfGame;

        [JsonPropertyName("attendance")]
        public int? Attendance;

        [JsonPropertyName("wp")]
        public string WinningPitcher = string.Empty;

        [JsonPropertyName("lp")]
        public string LosingPitcher = string.Empty;
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