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
    /// Interaction logic for TypeMaintenancePage.xaml
    /// </summary>
    public partial class TypeMaintenancePage : Page
    {
        
        public TypeMaintenancePage()
        {
            InitializeComponent();
            
            DGridTypeMaintenance.ItemsSource = AccountingEntities.GetContext().TypeMaintenances.ToList();
        }

        private void Add_Department_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditTypeMaintenance(null));
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditTypeMaintenance((sender as Button).DataContext as TypeMaintenance));
        }

        private void Delete_Department_Btn_Click(object sender, RoutedEventArgs e)
        {
            var TypeMaintenanceForRemoving = DGridTypeMaintenance.SelectedItems.Cast<TypeMaintenance>().ToList();

            if (MessageBox.Show($"Вы хотите удалть следующие {TypeMaintenanceForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEntities.GetContext().TypeMaintenances.RemoveRange(TypeMaintenanceForRemoving);
                    AccountingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridTypeMaintenance.ItemsSource = AccountingEntities.GetContext().TypeMaintenances.ToList();
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
                DGridTypeMaintenance.ItemsSource = AccountingEntities.GetContext().TypeMaintenances.ToList();
            }
        }
    }
}
