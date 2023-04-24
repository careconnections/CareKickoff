namespace CareConnections.Shared.Domain
{
    public class Report
    {
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool HasPriority { get; set; }
        public string CarePlanGoalId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}