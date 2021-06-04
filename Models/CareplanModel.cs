using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareKickoff.Models
{
    public class CareplanModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int ClientId { get; set; }
        public Goal[] Goals { get; set; }
    }

    public class Goal
    {
        public string DisplayName { get; set; }
        public int GoalId { get; set; }
    }
}
