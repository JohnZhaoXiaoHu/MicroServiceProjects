using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void OnProertyChanged(string proertyName);

        void SetProperty<T>(ref T feild, object value, [CallerMemberName] string propName = "");
    }
}
