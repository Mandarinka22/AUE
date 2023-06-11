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
    /// Логика взаимодействия для ClientSelectionForm.xaml
    /// </summary>
    public partial class ClientSelectionForm : Window
    {
        public Clients SelectedClient { get; private set; }
        DiplomaEntities DB;
        List<Clients> TB;
        public ClientSelectionForm()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Clients.ToList();
            ClientsGrid.ItemsSource = TB;
        }

        private void ClientsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получение выбранного клиента из DataGrid
            SelectedClient = ClientsGrid.SelectedItem as Clients;
        }

        private void AddClientService_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что клиент был выбран
            if (SelectedClient != null)
            {
                // Установка DialogResult для передачи выбранного клиента обратно в вызывающую форму
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Выберите клиента");
            }
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
    }
}
