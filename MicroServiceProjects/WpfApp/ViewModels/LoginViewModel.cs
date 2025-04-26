using System.Windows;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.ViewModel.Commands;
using WpfApp.Views.Home;

namespace WpfApp.ViewModels
{
    public class LoginViewModel: ViewModel
    {
        private Window _window;
        private static LoginDataModel _LoginDataModel = new LoginDataModel();

        public LoginViewModel(Window window)
        {
            _window = window;
            if (!_LoginDataModel.IsEnabled)
            {
                _LoginDataModel = new LoginDataModel();
            }
        }

        #region public method
        public string Username
        {
            get { return _LoginDataModel.Username; }
            set
            {
                _LoginDataModel.Username = value;
                OnProertyChanged("Username");
                //SetProperty(feild: ref _LoginDataModel.Username, value);
            }
        }

        public string Password
        {
            get { return _LoginDataModel.Password; }
            set
            {
                _LoginDataModel.Password = value;
                OnProertyChanged("Password");
            }
        }

        public bool IsEnabled
        {
            get { return _LoginDataModel.IsEnabled; }
            set
            {
                _LoginDataModel.IsEnabled = value;
                OnProertyChanged("IsEnabled");
            }
        }

        public ICommand LoginAction => new RelayCommand(Login, CanLoginAction);

        public ICommand CancleAction => new RelayCommand(Cancle, CanLoginAction);
        #endregion

        #region private Method
        private void Login()
        {
            if (Username == "wpf" && Password == "123456")
            {
                Home home = new Home();
                home.Show();
                _window.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                Username = string.Empty;
                Password = string.Empty;
            }
        }

        private void Cancle()
        {
            var result = MessageBox.Show("确定要退出此应用程序吗?", "提示...", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) Application.Current.Shutdown();
        }

        private bool CanLoginAction()
        {
            return true;
        } 
        #endregion
    }
}
