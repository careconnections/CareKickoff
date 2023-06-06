namespace CareKickoff.Models
{
    public interface IReportService
    {
        public Task<Report[]> GetReportsForClientAsync(int clientId);
    }
}
