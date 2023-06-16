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
    /// Interaction logic for AddEditJobTitlePage.xaml
    /// </summary>
    public partial class AddEditJobTitlePage : Page
    {
        private JobTitle _currentJobTitle = new JobTitle();
        public AddEditJobTitlePage()
        {
            InitializeComponent();
            DataContext = _currentJobTitle;
        }

        private void Save_Job_Title_Btn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentJobTitle.NameJobTitle))
                errors.AppendLine("Укажите название профессии");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentJobTitle.IdJobTitle == 0)
                AccountingEntities.GetContext().JobTitles.Add(_currentJobTitle);

            try
            {
                AccountingEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        
        }
    }

