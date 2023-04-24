using CareConnections.Shared.Domain;

namespace CareConnections.App.Services
{
    public interface IClientDataService
    {
        Task<IList<Client>?> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int clientId);
    }
}