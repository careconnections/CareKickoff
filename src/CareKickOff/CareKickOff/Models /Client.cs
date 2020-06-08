using System;
using Newtonsoft.Json;

namespace CareKickOff.Models
{
    public class Client
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("BirthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("NativeId")]
        public long NativeId { get; set; }
    }
}
