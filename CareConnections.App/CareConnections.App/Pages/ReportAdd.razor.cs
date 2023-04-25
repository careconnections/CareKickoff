using CareConnections.App.Services;
using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace CareConnections.App.Pages
{
    public partial class ReportAdd
    {
        [Inject]
        public IClientDataService ClientDataService { get; set; } = default!;
        [Inject]
        public IReportDataService ReportDataService { get; set; } = default!;
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

        [Parameter]
        public string ClientId { get; set; } = string.Empty;

        public Client? Client { get; set; } = new Client();

        public Report Report { get; set; } = new Report();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Client = await ClientDataService.GetClientByIdAsync(int.Parse(ClientId));
        }

        protected async Task HandleValidSubmitAsync()
        {
            Saved = false;

            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            Report.CreatedBy = state.User?.Identity?.Name;
            Report.CreatedAt = DateTime.UtcNow;
            Report.ClientId = ClientId;

            var addedReport = await ReportDataService.AddReportAsync(Report);
            if (addedReport != null)
            {
                StatusClass = "alert-success";
                Message = "New report added successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong adding the new report. Please try again.";
                Saved = false;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }
    }
}