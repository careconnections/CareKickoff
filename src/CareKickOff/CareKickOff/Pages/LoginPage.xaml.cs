using System;
using System.Collections.Generic;
using CareKickOff.ViewModels;
using Xamarin.Forms;

namespace CareKickOff.Pages
{
    public partial class LoginPage : BasePage<LoginViewModel>
    {
        public LoginPage(LoginViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
