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
    /// Interaction logic for DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Page
    {
        public DepartmentPage()
        {
            InitializeComponent();
            DGridDepartment.ItemsSource = AccountingEntities.GetContext().Departments.ToList();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditDepartmentPage((sender as Button).DataContext as Department));
        }

        private void Add_Department_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditDepartmentPage(null));
        }

        private void Delete_Department_Btn_Click(object sender, RoutedEventArgs e)
        {
            var DepartmentForRemoving = DGridDepartment.SelectedItems.Cast<Department>().ToList();

            if (MessageBox.Show($"Вы хотите удалть следующие {DepartmentForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEntities.GetContext().Departments.RemoveRange(DepartmentForRemoving);
                    AccountingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridDepartment.ItemsSource = AccountingEntities.GetContext().Departments.ToList();
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
                DGridDepartment.ItemsSource = AccountingEntities.GetContext().Departments.ToList();
            }
        } 
    }
}
