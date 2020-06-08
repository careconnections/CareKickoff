using System;
using Newtonsoft.Json;

namespace CareKickOff.Models
{
    public class Employee
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("EmployeeId")]
        public long EmployeeId { get; set; }

        [JsonProperty("AuthorizedClients")]
        public long[] AuthorizedClients { get; set; }
    }
}
