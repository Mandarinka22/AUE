using DimplomApp.AddingWindows;
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
using DimplomApp.WindowsProject;

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для NotariesControl.xaml
    /// </summary>
    public partial class NotariesControl : UserControl
    {
        DiplomaEntities DB;
        List<Notaries> TB;
        public NotariesControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Notaries.ToList();
            TableGrid.ItemsSource = TB;
        }
        private void refreshdatagrid()
        {
            TableGrid.ItemsSource = DB.Notaries.ToList();
            TableGrid.Items.Refresh();
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Search = DB.Notaries.ToList();
            Search = Search.Where(x => x.First_name.ToLower().Contains(Search_Box.Text.ToLower()) ||
            x.Last_name.ToLower().Contains(Search_Box.Text.ToLower())).ToList();         
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

        private void AddNotary_Click(object sender, RoutedEventArgs e)
        {
            var AN = new Notaries();
            DB.Notaries.Add(AN);
            AddNotary NewNotary = new AddNotary(DB, AN);
            NewNotary.ShowDialog();
            refreshdatagrid();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DB = new DiplomaEntities();
            Notaries Item = TableGrid.SelectedItem as Notaries;
            Notaries Delete = DB.Notaries.Where(d => d.ID_notary == Item.ID_notary).Single();
            DB.Notaries.Remove(Delete);
            DB.SaveChanges();
            MessageBox.Show("Строка успешно удалена!");
            refreshdatagrid();
        }
    }
}
