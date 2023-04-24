using CareConnections.Shared.Domain;
using System.Text.Json;

namespace CareConnections.Api.Models
{
    public class JsonParser
    {
        private static readonly JsonSerializerOptions _options =
            new(){ PropertyNameCaseInsensitive = true };

        public List<Client>? GetClientsFromJson(string filePath) =>
            JsonSerializer.Deserialize<List<Client>>(GetJsonString(filePath), _options);

        public List<Employee>? GetEmployeesFromJson(string filePath) =>
            JsonSerializer.Deserialize<List<Employee>>(GetJsonString(filePath), _options);

        public List<Report>? GetReportsFromJson(string filePath) =>
            JsonSerializer.Deserialize<List<Report>>(GetJsonString(filePath), _options);

        private static string GetJsonString(string filePath) =>
            File.ReadAllText(Path.Combine(Environment.CurrentDirectory, filePath));
    }
}
