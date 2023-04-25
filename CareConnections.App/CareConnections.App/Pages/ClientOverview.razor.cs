using CareConnections.App.Services;
using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Pages
{
    public partial class ClientOverview
    {
        [Inject]
        public IClientDataService ClientDataService { get; set; } = default!;
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; } = default!;

        public IList<Client>? Clients { get; set; } = default!;
        public IList<Employee>? Employees { get; set; } = default!;

        private Client? _selectedClient;

        private readonly string Title = "Client Overview";

        protected override async Task OnInitializedAsync()
        {
            Clients = await ClientDataService.GetAllClientsAsync();
            Employees = await EmployeeDataService.GetAllEmployeesAsync();
        }

        public void ShowClientDetailsPopup(Client selectedClient) =>
            _selectedClient = selectedClient;

        public bool IsEmployeeAuthorized(string? employeeName, int clientId)
        {
            var employee = Employees?
                .FirstOrDefault(e => e.Name == employeeName);

            return employee != null && IsEmployeeAuthorized(employee, clientId); ;
        }

        private static bool IsEmployeeAuthorized(Employee employee, int clientId) => 
            employee.AuthorizedClients
                .Split(',')
                .Select(int.Parse)
                .Contains(clientId);
    }
}