using CareConnections.App.Services;
using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Pages
{
    public partial class ReportOverview
    {
        [Inject]
        public IClientDataService ClientDataService { get; set; } = default!;
        [Inject]
        public IReportDataService ReportDataService { get; set; } = default!;


        [Parameter]
        public string ClientId { get; set; } = string.Empty;

        public Client? Client { get; set; } = new Client();
        public IList<Report>? Reports { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Client = await ClientDataService.GetClientByIdAsync(int.Parse(ClientId));

            var allReports = await ReportDataService.GetAllReportsAsync();
            Reports = allReports?
                .Where(r => r.ClientId == ClientId).ToList();
        }
    }
}
