using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Enums;
using CareKickoff.Domain.Interfaces.Entities;

namespace CareKickoff.Persistence.Records {
    internal class ClientRecord : IClient<EmployeeRecord, CareplanRecord> {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }

        [NotMapped]
        public IEnumerable<EmployeeRecord> Employees {
            get { return Authorizations.Select(_ => _.Employee); }
        }
        public IEnumerable<AuthorizationRecord> Authorizations { get; } = new List<AuthorizationRecord>();
        public IEnumerable<CareplanRecord> Careplans { get; set; } = new List<CareplanRecord>(); 

        public static ClientRecord FromEntity(ClientEntity entity) {
            return new ClientRecord {
                Id = entity.Id,
                CreationDate = entity.CreationDate,
                ModificationDate = entity.ModificationDate,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
                Gender = entity.Gender,
                Careplans = entity.Careplans?.Select(CareplanRecord.FromEntity)
            };
        }

        public ClientEntity ToEntity() {
            return new ClientEntity {
                Id = Id,
                CreationDate = CreationDate,
                ModificationDate = ModificationDate,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                Gender = Gender,
                Employees = Employees.Select(_ => _.ToEntity()),
                Careplans = Careplans.Select(_ => _.ToEntity())
            };
        }
    }
}