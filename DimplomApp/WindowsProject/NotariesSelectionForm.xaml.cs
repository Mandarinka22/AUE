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

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для NotariesSelectionForm.xaml
    /// </summary>
    public partial class NotariesSelectionForm : Window
    {
        DiplomaEntities DB;
        public Notaries SelectedNotary { get; private set; }
        public NotariesSelectionForm(DiplomaEntities db)
        {
            InitializeComponent();
            DB = db;
            // Загрузка данных из таблицы Notaries
            NotaryGrid.ItemsSource = DB.Notaries.ToList();
        }

        private void NotaryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNotary_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void NotaryGrid_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Получение выбранного нотариуса из DataGrid
            SelectedNotary = NotaryGrid.SelectedItem as Notaries;
            if (SelectedNotary != null)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Выберите нотариуса.", "Ошибка");
            }
        }
    }
}
