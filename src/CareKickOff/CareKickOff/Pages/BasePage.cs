using System;
using System.Threading.Tasks;
using CareKickOff.Pages.Interfaces;
using CareKickOff.ViewModels.Interfaces;
using Xamarin.Forms;

namespace CareKickOff.Pages
{
    public class BasePage<TViewModel> : ContentPage, IPage<TViewModel> where TViewModel : class, IViewModel
    {
        //current view model
        private readonly TViewModel _viewModel;

        public BasePage(TViewModel viewModel) : base()
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public TViewModel ViewModel => _viewModel;

        //initilize viewmodel for page
        public Task InitializeBindingContext()
        {
            BindingContext = ViewModel;

            return Task.FromResult(true);
        }

        //connect onappearing at the view model
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }

        //connect ondispearing to the view model
        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await _viewModel.OnDisappearing();
        }
    }
}
