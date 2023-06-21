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
    /// Interaction logic for AddEditEquipment.xaml
    /// </summary>
    public partial class AddEditEquipment : Page
    {
        private Equipment _currentEquipment = new Equipment();

        public AddEditEquipment(Equipment selectedEquipment)
        {
            InitializeComponent();
            
            if (selectedEquipment != null)
                _currentEquipment = selectedEquipment;

            DataContext = _currentEquipment;
            ComboDepartment.ItemsSource = AccountingEntities.GetContext().Departments.ToList();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEquipment.NameEquipment))
                errors.AppendLine("Укажите название оборудования");
            if (_currentEquipment.IdDepartment == null)
                errors.AppendLine("Выберите отдел");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentEquipment.IdEquipment == 0)
                AccountingEntities.GetContext().Equipments.Add(_currentEquipment);

            try
            {
                AccountingEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            NavigationService.GoBack();
        }
    }
}
