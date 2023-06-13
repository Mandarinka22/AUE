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
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        DiplomaEntities DB;
        public AddService(DiplomaEntities DB, Services_client Table)
        {
            InitializeComponent();
            this.DB = DB;
            this.DataContext = Table;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DB.SaveChanges();
            MessageBox.Show("Услуга успешно добавлена!", "Уведомление");
            this.Close();
        }

        private void PickClient_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра окна ClientSelectionForm
            ClientSelectionForm clientSelectionForm = new ClientSelectionForm();

            // Открытие окна ClientSelectionForm в режиме диалога
            bool? dialogResult = clientSelectionForm.ShowDialog();

            // Проверка результата диалога
            if (dialogResult == true)
            {
                // Получение выбранного клиента из окна ClientSelectionForm
                Clients selectedClient = clientSelectionForm.SelectedClient;

                // Установка значения ID выбранного клиента в TextBox
                ClientID.Text = selectedClient.ID_client.ToString();

                ((Services_client)this.DataContext).ClientID = selectedClient.ID_client;

                Client.Visibility= Visibility.Visible;

                ClientID.Visibility= Visibility.Visible;


                // Установка значения имени и фамилии выбранного клиента в TextBlock
                Client.Text = $"{selectedClient.First_name} {selectedClient.Last_name}";

                AddServiceBtn.Visibility= Visibility.Visible;
            }
        }
    }
}
