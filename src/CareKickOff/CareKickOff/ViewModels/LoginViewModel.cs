using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CareKickOff.Pages;
using CareKickOff.Services.Interfaces;
using Xamarin.Forms;

namespace CareKickOff.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IBasicAuthenticationService _basicAuthenticationService;
        private string _username;
        private string _password;

        public LoginViewModel(
            INavigationService navigationService,
            IBasicAuthenticationService basicAuthenticationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _basicAuthenticationService = basicAuthenticationService ?? throw new ArgumentNullException(nameof(basicAuthenticationService));
            LoginCommand = new Command(async () => await Login());
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }

        private async Task Login()
        {
            var isLoggedIn = _basicAuthenticationService.Login(int.Parse(Username), Password);
            if (isLoggedIn)
            {
                await _navigationService.Navigate<MainPage>(Enums.PagePresentationEnum.NewStackNavigation);
            }
          

        }
    }
}
