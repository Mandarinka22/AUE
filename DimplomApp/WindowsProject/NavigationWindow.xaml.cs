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

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : Window
    {
        public NavigationWindow()
        {
            InitializeComponent();
        }

        private void WindowClient_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new ClientsControl());
        }

        private void WindowNotary_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new NotariesControl());
        }

        private void WindowPrice_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new PriceControl());
        }

        private void WindowDocuments_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new DocumentsControl());
        }

        private void WindowServices_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new ServicesControl());
        }
        private void WindowExpenses_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new ExpensesControl());
        }

        private void WindowPayments_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new PaymentsControl());
        }

        private void WindowFinance_Click(object sender, RoutedEventArgs e)
        {
            Label.Visibility = Visibility.Collapsed;
            Frame.Navigate(new FinanceControl());
        }
    }
}
