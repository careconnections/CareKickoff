using CareConnection.Core.ViewModel;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CareConnection.Core.Model;
using CareConnection.Core.Pages;

namespace CareConnection.Core.View.Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientListPage : BaseContentPage<ClientViewModel>
    {
        Clients selectedClient;

        public ClientListPage(List<Clients> authorizedClients)
        {
            InitializeComponent();
            ViewModel.AuthorizedClients = authorizedClients;
        }

        #region Private Methods
        private void Display_Report(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new ReportPage(selectedClient));
        }

        private void Display_Care_Plans(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new CarePlanPage(selectedClient));
        }

        private void ListviewClients_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            displayReport.IsEnabled = true;
            carePlan.IsEnabled = true;
            selectedClient = (Clients)e.SelectedItem;
        }
        #endregion
    }
}