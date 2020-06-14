using System;
using System.Collections.Generic;
using CareKickOff.ViewModels;
using Xamarin.Forms;

namespace CareKickOff.Pages
{
    public partial class DetailClientPage : BasePage<DetailClientViewModel>
    {
        public DetailClientPage(DetailClientViewModel viewModel)
            :base(viewModel)
        {
            InitializeComponent();
        }
    }
}
