using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareKickoff.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public List<int> AuthorizedClients { get; set; }
    }
}
