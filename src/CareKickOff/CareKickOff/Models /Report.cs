using System;
using Newtonsoft.Json;

namespace CareKickOff.Models
{
    public class Report
    {
        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("HasPriority")]
        public bool HasPriority { get; set; }

        [JsonProperty("CarePlanGoalId")]
        public string CarePlanGoalId { get; set; }

        [JsonProperty("ClientId")]
        public long ClientId { get; set; }

        [JsonProperty("CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
