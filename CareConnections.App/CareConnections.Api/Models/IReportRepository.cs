using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public interface IReportRepository
    {
        IList<Report> GetAllReports();
        Report GetReportById(int reportId);
        Report AddReport(Report report);
        void DeleteReport(int reportId);
    }
}