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
    /// Логика взаимодействия для ServicesControl.xaml
    /// </summary>
    public partial class ServicesControl : UserControl
    {
        DiplomaEntities DB;
        List<Services_client> TB;
        public ServicesControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Services_client.ToList();
            TableGrid.ItemsSource = TB;
            refreshdatagrid();
        }

        private void refreshdatagrid()
        {
            TableGrid.ItemsSource = DB.Services_client.ToList();
            TableGrid.Items.Refresh();
        }

        private void AddServices_Click(object sender, RoutedEventArgs e)
        {
            var AS = new Services_client();
            DB.Services_client.Add(AS);
            AddService NewService = new AddService(DB, AS);
            NewService.ShowDialog();
            refreshdatagrid();
        }
    }
}
