using CareConnection.Core.Model;
using CareConnection.Core.Pages;
using CareConnection.Core.ViewModel;
using Xamarin.Forms.Xaml;

namespace CareConnection.Core.View.Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarePlanPage : BaseContentPage<CarePlanViewModel>
    {
        public CarePlanPage(Clients client)
        {
            ViewModel.Client = client;
            InitializeComponent();
        }
    }
}