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
    /// Interaction logic for AddEditMaintenancePage.xaml
    /// </summary>
    public partial class AddEditMaintenancePage : Page
    {
        private Maintenance _currentMaintenance = new Maintenance();
        public AddEditMaintenancePage(Maintenance selectedMaintenance)
        {
            InitializeComponent();

            if (selectedMaintenance != null) 
                _currentMaintenance = selectedMaintenance;

            DataContext = _currentMaintenance;
            ComboTypeMaintenance.ItemsSource = AccountingEntities.GetContext().TypeMaintenances.ToList();
            ComboEquipment.ItemsSource = AccountingEntities.GetContext().Equipments.ToList();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            //if (_currentMaintenance.IdTypeMaintenance == null)
            //    errors.AppendLine("Выберите тип обслуживания");
            if (_currentMaintenance.IdEquipment == null)
                errors.AppendLine("Выберите оборудование");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaintenance.IdMaintenance == 0)
                AccountingEntities.GetContext().Maintenances.Add(_currentMaintenance);

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
