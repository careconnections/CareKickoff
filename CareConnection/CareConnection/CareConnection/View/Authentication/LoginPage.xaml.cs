using CareConnection.Core.Pages;
using CareConnection.Core.View.Client;
using CareConnection.Core.ViewModel;
using System;
using Xamarin.Forms.Xaml;

namespace CareConnection.Core.View.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BaseContentPage<EmployeeViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        #region Private Methods
        private void SignIn_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.IsSuccessful)
                Navigation.PushModalAsync(new ClientListPage(ViewModel.GetAuthorizedClients()));
            else
                errormessage.Text = "Unable to find the Employee ID";
        }
        #endregion
    }
}