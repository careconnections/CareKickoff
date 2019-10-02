using System.Collections.Generic;

namespace CareKickoff.Domain.Interfaces.Entities {
    public interface IEmployee<out TClient> : IEntityWithTracking 
        where TClient : IEntity {
        string Name { get; set; } 
        IEnumerable<TClient> Clients { get; }
    }
}