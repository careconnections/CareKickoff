using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CareKickOff.Models;
using CareKickOff.Services.Interfaces;
using CareKickOff.ViewModels.Interfaces;

namespace CareKickOff.ViewModels
{
    public class DetailClientViewModel : ViewModel, IParameterViewModel<Client>
    {
        private readonly IClientDataService _clientDataService;
        private Client _currentClient;
        private ObservableCollection<Report> _reports;

        public DetailClientViewModel(IClientDataService clientDataService)
        {
            _clientDataService = clientDataService ?? throw new ArgumentNullException(nameof(clientDataService));
        }

        public void SetParameter(Client client)
        {
            CurrentClient = client;
            Reports = _clientDataService.GetReportsOfClient(client.NativeId);
        }

        public Client CurrentClient
        {
            get => _currentClient;
            set => SetProperty(ref _currentClient, value);
        }

        public ObservableCollection<Report> Reports
        {
            get => _reports;
            set => SetProperty(ref _reports, value);
        }
    }
}
