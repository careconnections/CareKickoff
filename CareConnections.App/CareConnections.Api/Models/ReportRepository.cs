using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReportRepository(AppDbContext appDbContext) => 
            _appDbContext = appDbContext;

        public IList<Report> GetAllReports() =>
            _appDbContext.Reports.ToList();

        public Report GetReportById(int reportId) =>
            _appDbContext.Reports.FirstOrDefault(r => r.ReportId == reportId);

        public Report AddReport(Report report)
        {
            var addedEntity = _appDbContext.Reports.Add(report);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteReport(int reportId)
        {
            var foundReport = _appDbContext.Reports.FirstOrDefault(r => r.ReportId == reportId);
            if (foundReport == null) 
                return;

            _appDbContext.Reports.Remove(foundReport);
            _appDbContext.SaveChanges();
        }
    }
}