using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.Templates.TextBoxs
{
    public class CustomTextBox : TextBox
    {
        public CornerRadius TextBoxRadius
        {
            get { return (CornerRadius)GetValue(TextBoxRadiusProperty); }
            set { SetValue(TextBoxRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextBoxRadiusProperty =
            DependencyProperty.Register("TextBoxRadius", typeof(CornerRadius), typeof(CustomTextBox));
    }
}
