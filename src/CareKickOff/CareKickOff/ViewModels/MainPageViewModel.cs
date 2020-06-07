using System;

namespace CareKickOff.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private string _beginText;

        public MainPageViewModel()
        {
            Title = "Test";
            BeginText = "Dit is een test text";
        }

        public string BeginText
        {
            get => _beginText;
            set => SetProperty(ref _beginText, value);
        }
    }
}
