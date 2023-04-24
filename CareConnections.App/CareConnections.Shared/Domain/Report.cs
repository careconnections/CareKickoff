using System.ComponentModel.DataAnnotations;

namespace CareConnections.Shared.Domain
{
    public class Report
    {
        public int ReportId { get; set; }

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Text { get; set; } = string.Empty;

        public bool HasPriority { get; set; }

        public string CarePlanGoalId { get; set; } = string.Empty;

        public string ClientId { get; set; } = string.Empty;

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}