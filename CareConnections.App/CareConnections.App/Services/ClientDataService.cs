using CareConnections.Shared.Domain;
using System.Text.Json;

namespace CareConnections.App.Services
{
    public class ClientDataService : IClientDataService
    {
        private readonly HttpClient _httpClient;

        public ClientDataService(HttpClient httpClient) =>
            _httpClient = httpClient;

        public async Task<IList<Client>?> GetAllClientsAsync() =>
            await JsonSerializer.DeserializeAsync<IList<Client>>
                (await _httpClient.GetStreamAsync($"api/client"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        public async Task<Client?> GetClientByIdAsync(int clientId) =>
            await JsonSerializer.DeserializeAsync<Client>
                (await _httpClient.GetStreamAsync($"api/client/{clientId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}