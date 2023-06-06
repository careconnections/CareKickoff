namespace CareKickoff.Models
{
    public interface ICareplanService
    {
        public Task<Careplan[]> GetCarePlansForClientAsync(int clientId);
    }
}
