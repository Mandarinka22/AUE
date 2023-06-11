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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для PriceControl.xaml
    /// </summary>
    public partial class PriceControl : UserControl
    {
        DiplomaEntities DB;
        List<Price_list> TB;
        public PriceControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Price_list.ToList();
            TableGrid.ItemsSource = TB;
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Search = DB.Price_list.ToList();
            Search = Search.Where(x => x.Type_documents.Type_name.ToLower().Contains(Search_Box.Text.ToLower())).ToList();
            if (Search.Count == 0)
            {
                MessageBox.Show("Нет результатов", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                TableGrid.ItemsSource = Search.ToList();
            }
        }
    }
}
