using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareKickoff.Data
{
    public class Employee
    {
        public String Name { get; set; }
        public int EmployeeId { get; set; }
        public List<int> AuthorizedClients { get; set; }
    }
}
