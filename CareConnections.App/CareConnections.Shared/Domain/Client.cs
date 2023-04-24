namespace CareConnections.Shared.Domain
{
    public class Client
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string NativeId { get; set; } = string.Empty;
    }
}