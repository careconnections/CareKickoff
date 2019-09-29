using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Entities;

namespace CareKickoff.Persistence.Records {
    internal class CareplanRecord : ICareplan {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int ClientId { get; set; }
        public ClientRecord Client { get; set; }
        
        public static CareplanRecord FromEntity(CareplanEntity entity) {
            return new CareplanRecord {
                Id = entity.Id,
                DisplayName = entity.DisplayName,
                ClientId = entity.ClientId
            };
        }

        public CareplanEntity ToEntity() {
            return new CareplanEntity {
                Id = Id,
                DisplayName = DisplayName,
                ClientId = ClientId
            };
        }
    }
}