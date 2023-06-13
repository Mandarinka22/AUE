using DimplomApp.DataBase;
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
using System.Windows.Shapes;
using DimplomApp.AddingWindows;

namespace DimplomApp.AddingWindows
{
    /// <summary>
    /// Логика взаимодействия для ServiceSelectionForm.xaml
    /// </summary>
    public partial class ServiceSelectionForm : Window
    {
        DiplomaEntities DB;
        public int SelectedServiceID { get; private set; }
        public ServiceSelectionForm(DiplomaEntities db)
        {
            InitializeComponent();
            DB = db;
            // Загрузка данных из таблицы Price_list
            ServiceGrid.ItemsSource = DB.Services_client.ToList();
        }
        private void ServiceGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            // Получение выбранной услуги из DataGrid
            Services_client selectedService = ServiceGrid.SelectedItem as Services_client;
            if (selectedService != null)
            {
                SelectedServiceID = selectedService.ID;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Выберите услугу.", "Ошибка");
            }

        }

        private void ServiceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
