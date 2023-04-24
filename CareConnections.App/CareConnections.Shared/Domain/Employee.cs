namespace CareConnections.Shared.Domain
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public List<string> AuthorizedClients { get; set; } = new List<string>();
    }
}