using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareKickoff.Models
{
    public class CareplanGoal
    {
        public string DisplayName { get; set; }
        public string GoalId { get; set; }
    }

    public class Careplan
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int ClientId { get; set; }
        public List<CareplanGoal> goals { get; set; }
    }
}
