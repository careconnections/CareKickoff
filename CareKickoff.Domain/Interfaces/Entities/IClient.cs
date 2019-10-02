using System;
using System.Collections.Generic;
using CareKickoff.Domain.Enums;

namespace CareKickoff.Domain.Interfaces.Entities {
    public interface IClient<TEmployee, TCareplan> : IEntityWithTracking 
        where TEmployee : IEntity
        where TCareplan : IEntity {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        GenderType Gender { get; set; }
        IEnumerable<TEmployee> Employees { get; }
        IEnumerable<TCareplan> Careplans { get; set; }
    }
}