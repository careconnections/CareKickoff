using CareConnections.Shared.Domain;

namespace CareConnections.App.Models
{
    public class MockDataService
    {
        private static List<Client>? _clients = default!;
        private static List<Report>? _reports = default!;

        public static List<Client> Clients
        {
            get
            {
                _clients ??= InitializeMockClients();

                return _clients;
            }
        }

        public static List<Report> Reports
        {
            get
            {
                _reports ??= InitializeMockReports();

                return _reports;
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

        private static List<Report> InitializeMockReports()
        {
            var r1 = new Report
            {
                Subject = "Subject",
                Text = "Text",
                HasPriority = false,
                CarePlanGoalId = "",
                ClientId = "1",
                CreatedBy = "Employee",
                CreatedAt = DateTime.Now
            };
            var r2 = new Report
            {
                Subject = "Test123",
                Text = "Let's see what it looks like for a longer message that contains a lot of blablablablablabla",
                HasPriority = false,
                CarePlanGoalId = "1",
                ClientId = "1",
                CreatedBy = "Employee2",
                CreatedAt = DateTime.Now
            };
            return new List<Report>() { r1, r2 };
        }
    }
}