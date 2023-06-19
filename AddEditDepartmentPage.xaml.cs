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
    /// Interaction logic for AddEditDepartmentPage.xaml
    /// </summary>
    public partial class AddEditDepartmentPage : Page
    {
        private Department _currentDepartment = new Department();
        public AddEditDepartmentPage(Department selectedDepartment)
        {
            InitializeComponent();

            if (selectedDepartment != null)
                _currentDepartment = selectedDepartment;

            DataContext = _currentDepartment;

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentDepartment.NameDepartment))
                errors.AppendLine("Укажите название отдела");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentDepartment.IdDepartment == 0)
                AccountingEntities.GetContext().Departments.Add(_currentDepartment);

            try
            {
                AccountingEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            NavigationService.GoBack();
        }
    }
}
