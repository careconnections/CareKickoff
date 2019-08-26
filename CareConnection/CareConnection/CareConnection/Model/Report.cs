using System;

namespace CareConnection.Core.Model
{
    public class Report
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public bool HasPriority { get; set; }
        public int? CarePlanGoalID { get; set; }
        public int ClientID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}