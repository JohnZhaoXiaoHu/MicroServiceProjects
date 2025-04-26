using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfApp.ViewModels
{
    public class ViewModel : IViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnProertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged!;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void SetProperty<T>(ref T feild, object value, [CallerMemberName] string propName = "")
        {
            feild = (T?)value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
