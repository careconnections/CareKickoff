using System.ComponentModel.DataAnnotations;
using CareKickoff.Domain.Interfaces.Entities;
using Newtonsoft.Json;

namespace CareKickoff.Domain.Entities {
    public class CareplanEntity : ICareplan {
        [JsonIgnore] 
        public int Id { get; set; }
        
        [Required]
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [Required]
        [JsonIgnore]
        public int ClientId { get; set; }
    }
}