using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.DP.DP
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            var ctb = new CustomTextBox();
            ctb.SetValue(IsHilightProperty, true);
        }

        public bool IsHilight
        {
            get { return (bool)GetValue(IsHilightProperty); }
            set { SetValue(IsHilightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsHilight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHilightProperty =
            DependencyProperty.Register(
                nameof(IsHilight),
                typeof(bool),
                typeof(CustomTextBox),
                new PropertyMetadata(false, CallBack));

        private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
