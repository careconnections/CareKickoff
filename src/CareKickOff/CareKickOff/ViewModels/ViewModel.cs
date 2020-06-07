using System;
using System.Threading.Tasks;
using CareKickOff.ViewModels.Interfaces;

namespace CareKickOff.ViewModels
{
    public class ViewModel : NotifyPropertyChanged, IViewModel
    {
        private string _title;

        public virtual string Title
        {
            get => (string.IsNullOrEmpty(_title)) ? string.Empty : _title;
            set => SetProperty(ref _title, value);
        }

        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnInitializing()
        {
            return Task.CompletedTask;
        }
    }
}
