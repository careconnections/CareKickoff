using CareKickoff.Models;
using CareKickoff.Properties;
using Newtonsoft.Json;

namespace CareKickoff.Data;

public class ReportService : IReportService
{
    public Task<Report[]> GetReportsForClientAsync(int clientId)
    {
        var careplans = LoadReportsJson();
        var reportsforclient = careplans.Where(i => i.ClientId == clientId).ToArray();
        return Task.FromResult(reportsforclient);
    }

    private List<Report> LoadReportsJson()
    {
        return JsonConvert.DeserializeObject<List<Report>>(Resources.reports.ToString()); ;
    }
}

