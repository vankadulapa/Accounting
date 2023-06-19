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
    /// Interaction logic for EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();
            DGridEqupment.ItemsSource = AccountingEntities.GetContext().Equipments.ToList();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditEquipment((sender as Button).DataContext as Equipment));
        }

        private void Add_Equipment_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditEquipment(null));
        }

        private void Delete_Equipment_Btn_Click(object sender, RoutedEventArgs e)
        {
            var EquipmentForRemoving = DGridEqupment.SelectedItems.Cast<Equipment>().ToList();

            if (MessageBox.Show($"Вы хотите удалть следующие {EquipmentForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEntities.GetContext().Equipments.RemoveRange(EquipmentForRemoving);
                    AccountingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridEqupment.ItemsSource = AccountingEntities.GetContext().Equipments.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


        }

        private void Page_IsVisibleChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AccountingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridEqupment.ItemsSource = AccountingEntities.GetContext().Equipments.ToList();
            }
        }
    }
}
