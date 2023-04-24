using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IList<Client> GetAllClients()
        {
            return _appDbContext.Clients.ToList();
        }

        public Client? GetClientById(string clientId)
        {
            return _appDbContext.Clients.FirstOrDefault(c => c.ClientId == int.Parse(clientId));
        }
    }
}