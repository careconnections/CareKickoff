using System;

namespace CareKickoff.Domain.Interfaces.Entities {
    public interface IEntityWithTracking : IEntity {
        DateTime CreationDate { get; set; }
        DateTime ModificationDate { get; set; }
    }
}