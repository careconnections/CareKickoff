using CareConnections.Shared.Domain;

namespace CareConnections.App.Services
{
    public interface IReportDataService
    {
        Task<IList<Report>?> GetAllReportsAsync();
    }
}