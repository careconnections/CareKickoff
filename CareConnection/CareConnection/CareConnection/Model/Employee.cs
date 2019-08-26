using System.Collections.Generic;

namespace CareConnection.Core.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public List<int> AuthorizedClients { get; set; }
    }
}