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

namespace DimplomApp.AddingWindows
{
    /// <summary>
    /// Логика взаимодействия для PriceSelectionForm.xaml
    /// </summary>
    public partial class PriceSelectionForm : Window
    {
        DiplomaEntities DB;
        public int SelectedPriceID { get; private set; }
        public PriceSelectionForm(DiplomaEntities db)
        {
            InitializeComponent();
            DB = db;
            // Загрузка данных из таблицы Price_list
            PriceGrid.ItemsSource = DB.Price_list.ToList();
        }
        private void PriceGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            // Получение выбранной услуги из DataGrid
            Price_list selectedPrice = PriceGrid.SelectedItem as Price_list;
            if (selectedPrice != null)
            {
                SelectedPriceID = selectedPrice.ID_price;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Выберите услугу.", "Ошибка");
            }

        }

        private void PriceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
