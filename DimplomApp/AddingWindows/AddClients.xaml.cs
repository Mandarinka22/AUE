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
using DimplomApp.DataBase;
using DimplomApp.WindowsProject;

namespace DimplomApp.AddingWindows
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        DiplomaEntities DB;
        public AddClients(DiplomaEntities DB, Clients Table)
        {
            InitializeComponent();
            this.DB = DB;
            this.DataContext = Table;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DB.SaveChanges();
            MessageBox.Show("Клиент успешно добавлен!", "Уведомление");
            this.Close();
        }
    }
}
