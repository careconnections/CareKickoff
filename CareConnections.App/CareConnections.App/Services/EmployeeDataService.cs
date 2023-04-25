using CareConnections.Shared.Domain;
using System.Text.Json;

namespace CareConnections.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpClient) =>
            _httpClient = httpClient;

        public async Task<IList<Employee>?> GetAllEmployeesAsync() =>
            await JsonSerializer.DeserializeAsync<IList<Employee>>
                (await _httpClient.GetStreamAsync($"api/employee"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        public async Task<Employee?> GetEmployeeByNameAsync(string employeeName) =>
            await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync($"api/employee/{employeeName}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}