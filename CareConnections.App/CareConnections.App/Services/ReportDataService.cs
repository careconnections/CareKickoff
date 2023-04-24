using CareConnections.Shared.Domain;
using System.Text;
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


        public async Task<Report?> AddReportAsync(Report report)
        {
            var reportJson = new StringContent(JsonSerializer.Serialize(report), 
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/report", reportJson);

            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<Report>(
                    await response.Content.ReadAsStreamAsync());

            return null;
        }

        public async Task DeleteReportAsync(int reportId) => 
            await _httpClient.DeleteAsync($"api/report/{reportId}");
    }
}