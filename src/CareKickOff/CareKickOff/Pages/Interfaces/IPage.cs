using System;
using System.Threading.Tasks;
using CareKickOff.ViewModels.Interfaces;

namespace CareKickOff.Pages.Interfaces
{
    public interface IPage<out TViewModel> where TViewModel : IViewModel
    {
        //Connected viewmodel
        TViewModel ViewModel { get; }
        //Initialize context of page
        Task InitializeBindingContext();
    }
}
