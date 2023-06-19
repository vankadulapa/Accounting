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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accounting.Models;


namespace Accounting
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = AppData.db.Users.FirstOrDefault(u => u.Login == LoginBox.Text);

            if (currentUser == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

            if (currentUser.Login == LoginBox.Text && currentUser.Password == PasswordBox.Password)
            {
                MessageBox.Show("Вы авторизованы");
                AppData.CurrentAccessLevel = currentUser.Role.RoleAccessLevel;
                NavigationService.Navigate(new ChosePage());
            }
            else
            {
                MessageBox.Show("Неправильный пароль");
            }
        }
    }
}
    

