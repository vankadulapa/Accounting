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
    /// Interaction logic for AddEditEmployeePage.xaml
    /// </summary>
    public partial class AddEditEmployeePage : Page
    {
        private Employee _currentEmployee = new Employee();
        public AddEditEmployeePage(Employee selectedEmployee)
        {
            InitializeComponent();

            if (selectedEmployee != null)
                _currentEmployee = selectedEmployee;

            DataContext = _currentEmployee;

            ComboDepartment.ItemsSource = AccountingEntities.GetContext().Departments.ToList();
            ComboJobTitle.ItemsSource = AccountingEntities.GetContext().JobTitles.ToList();
            ComboEquipment.ItemsSource = AccountingEntities.GetContext().Equipments.ToList();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEmployee.LastName))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentEmployee.FirstName))
                errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Patronymic))
                errors.AppendLine("Введите отчество");
            if (string.IsNullOrWhiteSpace(_currentEmployee.PhoneNumber))
                errors.AppendLine("Введите номер");
            if (_currentEmployee.IdDepartment == null)
                errors.AppendLine("Выберите отдел");
            if (_currentEmployee.IdEquipment == null)
                errors.AppendLine("Выберите оборудование");
            if (_currentEmployee.IdJobTitle == null)
                errors.AppendLine("Выберите профессии");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentEmployee.IdEmployee == 0)
                AccountingEntities.GetContext().Employees.Add(_currentEmployee);

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
