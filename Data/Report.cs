using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareKickoff.Data
{
    public class Report
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string HasPriority { get; set; }
        public string CarePlanGoalId { get; set; }
        public int ClientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt{ get; set; }
    }
}
