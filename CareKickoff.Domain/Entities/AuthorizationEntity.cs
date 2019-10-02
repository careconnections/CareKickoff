using System.ComponentModel.DataAnnotations;
using CareKickoff.Domain.Interfaces.Entities;
using Newtonsoft.Json;

namespace CareKickoff.Domain.Entities {
    public class AuthorizationEntity : IAuthorization {
        [JsonIgnore] 
        public int Id { get; set; }

        [Required]
        [JsonProperty("employeeId")]
        public int EmployeeId { get; set; }

        [Required] 
        [JsonProperty("clientId")]
        public int ClientId { get; set; }
    }
}