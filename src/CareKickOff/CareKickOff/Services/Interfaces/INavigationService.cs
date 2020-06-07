using System;
using System.Threading.Tasks;
using CareKickOff.Enums;
using CareKickOff.Pages.Interfaces;
using CareKickOff.ViewModels.Interfaces;

namespace CareKickOff.Services.Interfaces
{
    public interface INavigationService
    {
        Task Navigate<TPage>(PagePresentationEnum pagePresentation = PagePresentationEnum.AddToStackNavigation)
            where TPage : IPage<IViewModel>;
    }
}
