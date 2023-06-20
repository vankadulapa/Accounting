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
    /// Interaction logic for AddEditRolePage.xaml
    /// </summary>
    public partial class AddEditRolePage : Page
    {
        private Role _currentRole = new Role();
        public AddEditRolePage(Role selectedRole)
        {
            InitializeComponent();

            if (selectedRole != null) 
                _currentRole = selectedRole;

            DataContext = _currentRole;

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentRole.UserRoleId == 0)
                AccountingEntities.GetContext().Roles.Add(_currentRole);

            try
            {
                AccountingEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
