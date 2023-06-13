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

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для ExpensesControl.xaml
    /// </summary>
    public partial class ExpensesControl : UserControl
    {
        DiplomaEntities DB;
        List<Expenses> TB;
        public ExpensesControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Expenses.ToList();
            TableGrid.ItemsSource = TB;
        }
        private void refreshdatagrid()
        {
            TableGrid.ItemsSource = DB.Expenses.ToList();
            TableGrid.Items.Refresh();
        }

        private void AddExpenses_Click(object sender, RoutedEventArgs e)
        {
            var AE = new Expenses();
            DB.Expenses.Add(AE);
            AddExpenses NewExpenses = new AddExpenses(DB, AE);
            NewExpenses.ShowDialog();
            refreshdatagrid();
        }
    }
}
