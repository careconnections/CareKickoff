using System.Collections.Generic;

namespace CareConnection.Core.Model
{
    public class CarePlan
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int ClientId { get; set; }
        public List<Goal> Goals { get; set; }
    }
}