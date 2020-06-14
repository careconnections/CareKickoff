using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CareKickOff.Enums;
using CareKickOff.Pages.Interfaces;
using CareKickOff.Services.Interfaces;
using CareKickOff.ViewModels.Interfaces;
using Xamarin.Forms;

namespace CareKickOff.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public Task Navigate<TPage>(PagePresentationEnum pagePresentation = PagePresentationEnum.AddToStackNavigation) where TPage : IPage<IViewModel>
        {
            var page = AppContainer.Container.Resolve<TPage>();

            return Navigate(page, pagePresentation);
        }

        private Task Navigate(IPage<IViewModel> page, PagePresentationEnum presentation)
        {
            var xamFormsPage = page as Page;

            if(xamFormsPage == null)
            {
                throw new Exception($"page '{page}' is not of type {nameof(Page)}");
            }

            switch (presentation)
            {
                case PagePresentationEnum.AddToStackNavigation:
                    return NavigateOnCurrentNavigationPage(xamFormsPage);
                case PagePresentationEnum.NewStackNavigation:
                    return NavigateNewNavigationPage(xamFormsPage);
                case PagePresentationEnum.NoStackNavigation:
                    return NavigateNonNavigationPage(xamFormsPage);
                default:
                    throw new Exception($"Unsupported presentation type '{presentation}' not implemented in {nameof(NavigationService)}");
            }
        }

        private Task NavigateOnCurrentNavigationPage(Page page)
        {
            var mainPage = Application.Current.MainPage;
            if (mainPage.Navigation == null || !(mainPage is NavigationPage))
            {
                NavigateNewNavigationPage(page);
                return Task.FromResult(true);
            }
            else
            {
                return Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        private Task NavigateNonNavigationPage(Page page)
        {
            Device.BeginInvokeOnMainThread(
                () => Application.Current.MainPage = page
            );

            return Task.FromResult(true);
        }

        private Task NavigateNewNavigationPage(Page page)
        {

            Device.BeginInvokeOnMainThread(
                () => Application.Current.MainPage = new NavigationPage(page)
            );

            return Task.FromResult(true);
        }

        public Task Navigate<TPage, TParameter>(TParameter parameter, PagePresentationEnum presentationEnum = PagePresentationEnum.AddToStackNavigation) where TPage : IPage<IViewModel>
        {
            var page = AppContainer.Container.Resolve<TPage>();

            if(page.ViewModel is IParameterViewModel<TParameter> parameterViewModel)
            {
                parameterViewModel.SetParameter(parameter);
            }

            return Navigate(page, presentationEnum);
        }
    }
}
