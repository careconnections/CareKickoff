using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Entities;

namespace CareKickoff.Persistence.Records {
    internal class AuthorizationRecord : IAuthorization {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeRecord Employee { get; set; }
 
        public int ClientId { get; set; }
        public ClientRecord Client { get; set; }
        
        public static AuthorizationRecord FromEntity(AuthorizationEntity entity) {
            return new AuthorizationRecord {
                Id = entity.Id,
                ClientId = entity.ClientId,
                EmployeeId = entity.EmployeeId
            };
        }

        public AuthorizationEntity ToEntity() {
            return new AuthorizationEntity {
                Id = Id,
                ClientId = ClientId,
                EmployeeId = EmployeeId
            };
        }
    }
}