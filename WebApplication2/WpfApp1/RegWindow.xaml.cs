using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebApplication2.Models;
using WpfApp1.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void loginBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private async void regBTN_Click(object sender, RoutedEventArgs e)
        {
            var res = await Api.Reg(surname: surnameTB.Text, name: nameTB.Text, patronymic: patronymicTB.Text, login: loginTB.Text, password: passwordTB.Text);

            if (res is User)
            {
                MessageBox.Show("Регистрация прошла успешно!");
            }
            else
            {
                MessageBox.Show("Введите данные корректно");
            }
        }
    }
}
