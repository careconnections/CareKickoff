using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using CareKickOff.Models;
using CareKickOff.Pages;
using CareKickOff.Services.Interfaces;
using Xamarin.Forms;

namespace CareKickOff.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly IClientDataService _clientDataService;
        private readonly INavigationService _navigationService;
        private Client _selectedClient;
        private string _beginText;

        public MainPageViewModel(IClientDataService clientDataService,
                                 INavigationService navigationService)
        {
            _clientDataService = clientDataService ?? throw new ArgumentNullException(nameof(clientDataService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            Title = "Clients";
            BeginText = "Dit is een test text";
            Clients = _clientDataService.GetClients(Config.Username);

            NavigateClientCommand = new Command<Client>(async (client) => await NavigateToClient(client));
        }

        public override Task OnAppearing()
        {
            return base.OnAppearing();
        }

        public string BeginText
        {
            get => _beginText;
            set => SetProperty(ref _beginText, value);
        }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                SetProperty(ref _selectedClient, value);
                var task = NavigateToClient(value);
            }
        }

        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();

        public ICommand NavigateClientCommand { get;  }


        private async Task NavigateToClient(Client client)
        {
            await _navigationService.Navigate<DetailClientPage, Client>(client);
        }
    }
}
