namespace CareConnections.Shared.Domain
{
    public class CarePlan
    {
        public string Id { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public List<Goal> Goals { get; set; } = new List<Goal>();
    }
}