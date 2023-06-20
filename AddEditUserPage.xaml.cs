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

namespace Accounting
{
    /// <summary>
    /// Interaction logic for AddEditUserPage.xaml
    /// </summary>
    public partial class AddEditUserPage : Page
    {
        private User _currentUser = new User();
        public AddEditUserPage(User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null) 
                _currentUser = selectedUser;

            DataContext = _currentUser;
            ComboRoles.ItemsSource = AccountingEntities.GetContext().Roles.ToList();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Укажите пароль");
            if (_currentUser.UserRoleId == null)
                errors.AppendLine("Назначьте роль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.Id == 0)
                AccountingEntities.GetContext().Users.Add(_currentUser);

            try
            {
                AccountingEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
