using CareConnections.Shared.Domain;
using System.Text.Json;

namespace CareConnections.App.Services
{
    public class ReportDataService : IReportDataService
    {
        private readonly HttpClient _httpClient;

        public ReportDataService(HttpClient httpClient) =>
            _httpClient = httpClient;

        public async Task<IList<Report>?> GetAllReportsAsync() =>
            await JsonSerializer.DeserializeAsync<IList<Report>>
                (await _httpClient.GetStreamAsync($"api/report"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}