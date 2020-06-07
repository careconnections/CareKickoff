using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CareKickOff
{
    public class NotifyPropertyChanged : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public event PropertyChangingEventHandler PropertyChanging = delegate { };


        protected bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName] string propertyName = null,
            Action onChanged = null,
            Action<T> onChanging = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            onChanging?.Invoke(value);
            OnPropertyChanging(propertyName);

            backingStore = value;

            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
