namespace CareKickoff.Domain.Interfaces.Entities {
    public interface IAuthorization : IEntity {
        int EmployeeId { get; set; }
        int ClientId { get; set; }
    }
}