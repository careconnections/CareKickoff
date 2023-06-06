namespace CareKickoff.Models
{
    public interface IClientService
    {
        public Task<Client[]> GetAllClientsAsync();

        public Task<Client> GetClientByIdAsync(int id);
    }
}
