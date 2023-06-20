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
    /// Interaction logic for RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public RolePage()
        {
            InitializeComponent();
            DGridRole.ItemsSource = AccountingEntities.GetContext().Roles.ToList();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRolePage((sender as Button).DataContext as Role));
        }

        private void Add_Role_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRolePage(null));
        }

        private void Delete_Role_Btn_Click(object sender, RoutedEventArgs e)
        {
            var RoleForRemoving = DGridRole.SelectedItems.Cast<Role>().ToList();

            if (MessageBox.Show($"Вы хотите удалть следующие {RoleForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEntities.GetContext().Roles.RemoveRange(RoleForRemoving);
                    AccountingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridRole.ItemsSource = AccountingEntities.GetContext().Roles.ToList();
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
                DGridRole.ItemsSource = AccountingEntities.GetContext().Roles.ToList();
            }
        }
    }
}
