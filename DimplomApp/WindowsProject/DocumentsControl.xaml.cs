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
    /// Логика взаимодействия для DocumentsControl.xaml
    /// </summary>
    public partial class DocumentsControl : UserControl
    {
        DiplomaEntities DB;
        List<Documents> TB;
        public DocumentsControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Documents.ToList();
            TableGrid.ItemsSource = TB;

        }

        private void refreshdatagrid()
        {
            TableGrid.ItemsSource = DB.Documents.ToList();
            TableGrid.Items.Refresh();
        }

        private void AddDocuments_Click(object sender, RoutedEventArgs e)
        {
            var AD = new Documents();
            DB.Documents.Add(AD);
            AddDocuments NewDocuments = new AddDocuments(DB, AD);
            NewDocuments.ShowDialog();
            refreshdatagrid();
        }
    }
}
