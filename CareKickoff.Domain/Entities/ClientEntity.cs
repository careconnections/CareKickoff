using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CareKickoff.Domain.Enums;
using CareKickoff.Domain.Interfaces.Entities;
using Newtonsoft.Json;

namespace CareKickoff.Domain.Entities {
    public class ClientEntity : IClient<EmployeeEntity, CareplanEntity> {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        
        [JsonIgnore]
        public DateTime ModificationDate { get; set; }
        
        [Required]
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        
        [Required]
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        
        [Required]
        [JsonProperty("birthdate")]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [JsonProperty("gender")]
        public GenderType Gender { get; set; }

        [JsonIgnore]
        public IEnumerable<EmployeeEntity> Employees { get; set; }
        
        [JsonIgnore]
        public IEnumerable<CareplanEntity> Careplans { get; set; }
    }
}