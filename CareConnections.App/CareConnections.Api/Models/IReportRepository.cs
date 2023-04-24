using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public interface IReportRepository
    {
        IList<Report>? GetAllReports();
    }
}