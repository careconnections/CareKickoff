using CareConnections.App.Models;
using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Pages
{
    public partial class ReportOverview
    {
        [Parameter]
        public string ClientId { get; set; } = string.Empty;

        public Client Client { get; set; } = new Client();
        public List<Report> Reports { get; set; } = default!;

        protected override void OnInitialized()
        {
            Client = MockDataService.Clients
                .First(c => c.NativeId == ClientId);
            Reports = MockDataService.Reports
                .Where(r => r.ClientId == ClientId).ToList();
        }
    }
}
