using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CaseApp.Annotations;
using CaseApp.Models;
using Xamarin.Forms;

namespace CaseApp.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged { 

        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}