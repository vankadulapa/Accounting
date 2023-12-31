﻿using System;
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
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            DGridEmployee.ItemsSource = AccountingEntities.GetContext().Employees.ToList();
        }

        private void Add_Employee_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditEmployeePage(null));
        }

        private void Btn_Edit_Employee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditEmployeePage((sender as Button).DataContext as Employee));
        }

        private void Delete_Employee_Btn_Click(object sender, RoutedEventArgs e)
        {
            var EmployeeForRemoving = DGridEmployee.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы хотите удалть следующие {EmployeeForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEntities.GetContext().Employees.RemoveRange(EmployeeForRemoving);
                    AccountingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridEmployee.ItemsSource = AccountingEntities.GetContext().Employees.ToList();
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
                DGridEmployee.ItemsSource = AccountingEntities.GetContext().Employees.ToList();
            }
        }
    }
}

