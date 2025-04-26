using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.Templates.Buttons
{
    public class CustomButton : Button
    {
        public CornerRadius ButtonRadius
        {
            get { return (CornerRadius)GetValue(ButtonRadiusProperty); }
            set { SetValue(ButtonRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonRadiusProperty =
            DependencyProperty.Register("ButtonRadius", typeof(CornerRadius), typeof(CustomButton));


    }
}
