using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CareKickoff.Domain.Interfaces.Entities;
using Newtonsoft.Json;

namespace CareKickoff.Domain.Entities {
    public class EmployeeEntity : IEmployee<ClientEntity> {
        [JsonIgnore]
        public int Id { get; set; }
        
        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime ModificationDate { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonIgnore]
        public IEnumerable<ClientEntity> Clients { get; set; }
    }
}