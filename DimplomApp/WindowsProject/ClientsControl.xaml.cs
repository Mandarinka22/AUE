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
using DimplomApp.DataBase;
using DimplomApp.AddingWindows;

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для ClientsControl.xaml
    /// </summary>
    public partial class ClientsControl : UserControl
    {
        DiplomaEntities DB;
        List<Clients> TB;
        public ClientsControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Clients.ToList();
            ClientsGrid.ItemsSource = TB;
        }
        private void refreshdatagrid()
        {
            ClientsGrid.ItemsSource = DB.Clients.ToList();
            ClientsGrid.Items.Refresh();
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Search = DB.Clients.ToList();
            Search = Search.Where(x => x.First_name.ToLower().Contains(Search_Box.Text.ToLower()) ||
            x.Last_name.ToLower().Contains(Search_Box.Text.ToLower())).ToList();       
            if (Search.Count == 0)
            {
                MessageBox.Show("Нет результатов", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ClientsGrid.ItemsSource = Search.ToList();
            }
        }

        private void AddClients_Click(object sender, RoutedEventArgs e)
        {
            var AC = new Clients();
            DB.Clients.Add(AC);
            AddClients NewClient = new AddClients(DB, AC);
            NewClient.ShowDialog();
            refreshdatagrid();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DB = new DiplomaEntities();
            Clients Item = ClientsGrid.SelectedItem as Clients;
            Clients Delete = DB.Clients.Where(d => d.ID_client == Item.ID_client).Single();
            DB.Clients.Remove(Delete);
            DB.SaveChanges();
            MessageBox.Show("Строка успешно удалена!");
            refreshdatagrid();
        }
    }
}
