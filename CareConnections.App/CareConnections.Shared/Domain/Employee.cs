namespace CareConnections.Shared.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AuthorizedClients { get; set; } = string.Empty;
    }
}