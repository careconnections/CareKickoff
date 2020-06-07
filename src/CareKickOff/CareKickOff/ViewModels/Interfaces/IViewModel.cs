using System;
using System.Threading.Tasks;

namespace CareKickOff.ViewModels.Interfaces
{
    public interface IViewModel
    {
        Task OnInitializing();
        Task OnAppearing();
        Task OnDisappearing();

        string Title { get; set; }
    }
}
