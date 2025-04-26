
using System.Windows;
using WpfApp.ViewModels;

namespace WpfApp.Views.Home
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private static DeviceViewModel _deviceViewModel;
        public Home()
        {
            InitializeComponent();
            ReFressData();
        }

        private void Btn_ComeBackLogin(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Visibility = Visibility.Visible;
            this.Hide();
        }

        private void Btn_RefresData(object sender, RoutedEventArgs e)
        {
            ReFressData();
        }

        private void ReFressData()
        {
            _deviceViewModel = new DeviceViewModel();
            this.DataContext = _deviceViewModel;
        }
    }
}
