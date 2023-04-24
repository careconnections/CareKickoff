using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext) => 
            _appDbContext = appDbContext;

        public IList<Client> GetAllClients() =>
            _appDbContext.Clients.ToList();

        public Client GetClientById(int clientId) =>
            _appDbContext.Clients.FirstOrDefault(c => c.ClientId == clientId);
    }
}