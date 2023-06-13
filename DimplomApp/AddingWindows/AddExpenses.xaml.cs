using DimplomApp.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using DimplomApp;

namespace DimplomApp.AddingWindows
{
    /// <summary>
    /// Логика взаимодействия для AddExpenses.xaml
    /// </summary>
    public partial class AddExpenses : Window
    {
        DiplomaEntities DB;
        public AddExpenses(DiplomaEntities DB, Expenses Table)
        {
            InitializeComponent();
            this.DB = DB;
            this.DataContext = Table;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DB.SaveChanges();
            MessageBox.Show("Трата успешно добавлен!", "Уведомление");
            this.Close();
        }
    }
}
