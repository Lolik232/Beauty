using Beauty.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
