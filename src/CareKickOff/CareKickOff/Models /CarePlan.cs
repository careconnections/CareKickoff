using Newtonsoft.Json;

namespace CareKickOff.Models
{
    public class Temperatures
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("ClientId")]
        public long ClientId { get; set; }

        [JsonProperty("Goals")]
        public Goal[] Goals { get; set; }
    }
}
