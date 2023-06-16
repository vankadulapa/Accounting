using System;
using System.CodeDom;
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
    /// Interaction logic for JobTitlePage.xaml
    /// </summary>
    public partial class JobTitlePage : Page
    {
        public JobTitlePage()
        {
            InitializeComponent();
            DGridJobTitle.ItemsSource = AccountingEntities.GetContext().JobTitles.ToList();
        }

        private void Btn_Edit_Job_Title_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditJobTitlePage((sender as Button).DataContext as JobTitle));
        }

        private void Add_Job_Title_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditJobTitlePage(null));
        }

        private void Delete_Job_Title_Btn_Click(object sender, RoutedEventArgs e)
        {
            var JobTitleForRemoving = DGridJobTitle.SelectedItems.Cast<JobTitle>().ToList();

            if (MessageBox.Show($"Вы хотите удалть следующие {JobTitleForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEntities.GetContext().JobTitles.RemoveRange(JobTitleForRemoving);
                    AccountingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridJobTitle.ItemsSource = AccountingEntities.GetContext().JobTitles.ToList();
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
                DGridJobTitle.ItemsSource = AccountingEntities.GetContext().JobTitles.ToList();
            }
        }
    }
}
