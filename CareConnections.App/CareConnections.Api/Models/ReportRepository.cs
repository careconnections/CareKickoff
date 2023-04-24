using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReportRepository(AppDbContext appDbContext) => 
            _appDbContext = appDbContext;

        public IList<Report>? GetAllReports() =>
            _appDbContext?.Reports?.ToList();
    }
}