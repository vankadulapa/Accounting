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

        }

        private void Add_Job_Title_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditJobTitlePage());
        }

        private void Delete_Job_Title_Btn_Click(object sender, RoutedEventArgs e)
        {

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
