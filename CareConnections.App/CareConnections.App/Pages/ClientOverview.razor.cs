using CareConnections.App.Services;
using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace CareConnections.App.Pages
{
    public partial class ClientOverview
    {
        [Inject]
        public IClientDataService ClientDataService { get; set; } = default!;
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; } = default!;
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;
        

        public IList<Client>? Clients { get; set; } = default!;

        private Client? _selectedClient;

        private readonly string Title = "Client Overview";

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var employeeName = state.User?.Identity?.Name;
            if (string.IsNullOrWhiteSpace(employeeName))
                return;

            var employee = await EmployeeDataService.GetEmployeeByNameAsync(employeeName);
            if (employee == null)
                return;

            var allClients = await ClientDataService.GetAllClientsAsync();
            if (allClients == null)
                return;

            var authorizedClientIds = employee.AuthorizedClients.Split(',').Select(int.Parse).ToList();

            Clients = allClients.Where(c => authorizedClientIds.Contains(c.ClientId)).ToList();
        }

        public void ShowClientDetailsPopup(Client selectedClient) =>
            _selectedClient = selectedClient;
    }
}