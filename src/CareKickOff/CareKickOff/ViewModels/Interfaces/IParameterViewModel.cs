using System;
namespace CareKickOff.ViewModels.Interfaces
{
    public interface IParameterViewModel<T> : IViewModel
    {
        void SetParameter(T parameter);
    }
}
