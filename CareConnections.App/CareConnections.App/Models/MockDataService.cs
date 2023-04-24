using CareConnections.Shared.Domain;

namespace CareConnections.App.Models
{
    public class MockDataService
    {
        private static List<Client>? _clients = default!;

        public static List<Client> Clients
        {
            get
            {
                _clients ??= InitializeMockClients();

                return _clients;
            }
        }

        private static List<Client> InitializeMockClients()
        {
            var c1 = new Client
            {
                FirstName = "Test",
                LastName = "Tester",
                BirthDate = new DateTime(2023, 4, 24),
                Gender = Gender.Female,
                NativeId = "1"
            };
            var c2 = new Client
            {
                FirstName = "Rik",
                LastName = "Brouwer",
                BirthDate = new DateTime(1988, 5, 8),
                Gender = Gender.Male,
                NativeId = "2"
            };
            return new List<Client>() { c1, c2 };
        }
    }
}