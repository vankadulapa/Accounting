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
    /// Interaction logic for ChosePage.xaml
    /// </summary>
    public partial class ChosePage : Page
    {
        public ChosePage()
        {
            InitializeComponent();
        }

        private void JobTitle_Btn_CLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new JobTitlePage());
        }

        private void Employee_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeePage());
        }

        private void Equipment_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EquipmentPage());
        }

        private void Department_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentPage());
        }

        private void Maintenance_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaintenancePage());
        }

        private void Type_Maintenance_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TypeMaintenance());
        }

        private void User_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Role_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Otchet_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
