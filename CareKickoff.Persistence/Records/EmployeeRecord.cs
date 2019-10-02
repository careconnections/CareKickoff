using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Entities;

namespace CareKickoff.Persistence.Records {
    internal class EmployeeRecord : IEmployee<ClientRecord> {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public IEnumerable<ClientRecord> Clients {
            get { return Authorizations.Select(_ => _.Client); }
        }
        
        public IEnumerable<AuthorizationRecord> Authorizations { get; } = new List<AuthorizationRecord>();

        public static EmployeeRecord FromEntity(EmployeeEntity entity) {
            return new EmployeeRecord {
                Id = entity.Id,
                CreationDate = entity.CreationDate,
                ModificationDate = entity.ModificationDate,
                Name = entity.Name
            };
        }

        public EmployeeEntity ToEntity() {
            return new EmployeeEntity {
                Id = Id,
                CreationDate = CreationDate,
                ModificationDate = ModificationDate,
                Name = Name,
                Clients = Clients.Select(_ => _.ToEntity())
            };
        }
    }
}