using Newtonsoft.Json;

namespace CareKickOff.Models
{
    public class Goal
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("GoalId")]
        public long GoalId { get; set; }
    }
}
