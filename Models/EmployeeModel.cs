using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareKickoff.Models
{
    public class EmployeeModel
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public int[] AuthorizedClients { get; set; }

        public bool IsAuthorized { get; set; }

        public int SelectedClientId { get; set; }

    }
}
