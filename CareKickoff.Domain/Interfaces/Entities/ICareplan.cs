namespace CareKickoff.Domain.Interfaces.Entities {
    public interface ICareplan : IEntity {
        string DisplayName { get; set; }
        int ClientId { get; set; }
    }
}