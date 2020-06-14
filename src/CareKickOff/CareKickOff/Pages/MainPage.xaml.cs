using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareKickOff.Pages;
using CareKickOff.ViewModels;
using Xamarin.Forms;

namespace CareKickOff.Pages
{
    public partial class MainPage : BasePage<MainPageViewModel>
    {
        public MainPage(MainPageViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
            
        }
    }
}
