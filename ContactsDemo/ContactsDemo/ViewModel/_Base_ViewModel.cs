using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ContactsDemo.ViewModel
{
    public abstract class _Base_ViewModel : INotifyPropertyChanged
    {

        // ViewModels within this MVVM framework will implement INotifyProperty Changed on their properties mutator
        // Based on the Charles Petzold implementation from Creating Mobile Apps with Xamarin.Forms

        private bool _isBusy;
        public bool PropertyIsBusy
        {
            set { SetProperty(ref _isBusy, value); }
            get { return _isBusy; }
        }

        private bool _UIVisible;
        public bool PropertyUIVisible
        {
            set { SetProperty(ref _UIVisible, value); }
            get { return _UIVisible; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
