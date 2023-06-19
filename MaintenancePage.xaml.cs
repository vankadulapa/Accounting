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
    /// Interaction logic for MaintenancePage.xaml
    /// </summary>
    public partial class MaintenancePage : Page
    {
        public MaintenancePage()
        {
            InitializeComponent();
            DGridMaintance.ItemsSource = AccountingEntities.GetContext().Maintenances.ToList();
        }

        private void Add_Department_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditMaintenancePage(null));
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditMaintenancePage((sender as Button).DataContext as Maintenance));
        }

        private void Delete_Department_Btn_Click(object sender, RoutedEventArgs e)
        {
            var MaintenanceForRemoving = DGridMaintance.SelectedItems.Cast<Maintenance>().ToList();

            if (MessageBox.Show($"Вы хотите удалть следующие {MaintenanceForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEntities.GetContext().Maintenances.RemoveRange(MaintenanceForRemoving);
                    AccountingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridMaintance.ItemsSource = AccountingEntities.GetContext().Maintenances.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AccountingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridMaintance.ItemsSource = AccountingEntities.GetContext().Maintenances.ToList();
            }
        }
    }
}
