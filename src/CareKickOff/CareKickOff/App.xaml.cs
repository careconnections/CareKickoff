using System;
using System.Threading.Tasks;
using Autofac;
using CareKickOff.Pages;
using CareKickOff.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CareKickOff
{
    public partial class App : Application
    {
        public App()
        {
            AppContainer.Initialize();
            InitializeComponent();

            MainPage = new ContentPage();
        }

        protected override void OnStart()
        {
            var scope = AppContainer.Container.BeginLifetimeScope();
            var navigationService = scope.Resolve<INavigationService>();
            Task.Run(() => navigationService.Navigate<LoginPage>(Enums.PagePresentationEnum.NoStackNavigation));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
