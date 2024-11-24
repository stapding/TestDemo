using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebApplication2.Models;
using WpfApp1.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void regBTN_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }

        private async void loginBTN_Click(object sender, RoutedEventArgs e)
        {
            var res = await Api.Auth(login: loginTB.Text, password: passwordTB.Text);
            if (res is User)
            {
                MessageBox.Show("Авторизация прошла успешно!");
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}