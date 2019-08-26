using Xamarin.Forms;

namespace CareConnection.Core.Pages
{
    public class BaseContentPage<TViewModel> : ContentPage where TViewModel : new()
    {
        protected BaseContentPage()
        {
            InitializeViewModel();
        }

        #region Properties
        public TViewModel ViewModel { get; private set; }
        #endregion

        #region Private
        private void InitializeViewModel()
        {
            ViewModel = new TViewModel();
            BindingContext = ViewModel;
        }
        #endregion
    }
}