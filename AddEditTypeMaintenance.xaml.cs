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
    /// Interaction logic for AddEditTypeMaintenance.xaml
    /// </summary>
    public partial class AddEditTypeMaintenance : Page
    {
        private TypeMaintenance _curentTypeMaintenance = new TypeMaintenance();
        public AddEditTypeMaintenance(TypeMaintenance selectedTypeMaintenance)
        {
            InitializeComponent();
            if (selectedTypeMaintenance != null) 
                _curentTypeMaintenance = selectedTypeMaintenance;
            DataContext = _curentTypeMaintenance;

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_curentTypeMaintenance.NameMaintenance))
                errors.AppendLine("Введите название тех.обсл.");
            if ((_curentTypeMaintenance.Duration) == null)
                errors.AppendLine("Введите длительность");
            if ((_curentTypeMaintenance.Expenses) == null)
                errors.AppendLine("Введите стоимость");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_curentTypeMaintenance.IdTypeMaintenance == null)
                AccountingEntities.GetContext().TypeMaintenances.Add(_curentTypeMaintenance);
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
