using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.Templates.PasswordBoxs
{
    public class PasswordBoxHelper
    {
        public static string GetPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(PwdProperty);
        }

        public static void SetPwd(DependencyObject obj, string value)
        {
            obj.SetValue(PwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdProperty =
            DependencyProperty.RegisterAttached("Pwd", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnPwdPropertyChanged));

        private static void OnPwdPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox? pwdBox = d as PasswordBox;  
            if (pwdBox == null) return;

            pwdBox.Password = e.NewValue?.ToString();

            SetSelection(pwdBox);
        }

        private static void SetSelection(PasswordBox pwdBox)
        {
            pwdBox.GetType()
                .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(pwdBox, new object[] { pwdBox.Password.Length, 0 });
        }

        public static bool GetIsEnablePasswordPropertyChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnablePasswordPropertyChangedProperty);
        }

        public static void SetIsEnablePasswordPropertyChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnablePasswordPropertyChangedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsEnablePasswordPropertyChanged.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnablePasswordPropertyChangedProperty =
            DependencyProperty.RegisterAttached("IsEnablePasswordPropertyChanged", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false, OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox = d as PasswordBox;
            if (pwdBox == null) return;

            if ((bool)e.NewValue)
            {
                pwdBox.PasswordChanged += OnPasswordChanged;
            }
            else
            {
                pwdBox.PasswordChanged -= OnPasswordChanged;
            }
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pwdBox = (PasswordBox)sender;
            SetPwd(pwdBox, pwdBox.Password);
        }
    }
}
