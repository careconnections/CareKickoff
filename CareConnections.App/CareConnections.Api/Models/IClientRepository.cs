using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public interface IClientRepository
    {
        IList<Client> GetAllClients();
        Client GetClientById(int clientId);
    }
}