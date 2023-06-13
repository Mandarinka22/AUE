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
using DimplomApp.WindowsProject;

namespace DimplomApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DiplomaEntities DB;
        public MainWindow()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            // Проверка существования пользователя с указанным логином и паролем
            var user = DB.Authorization.FirstOrDefault(a => a.Login == username && a.Password == password);
            if (user != null)
            {
                // Открытие главного окна при успешной авторизации
                DimplomApp.WindowsProject.NavigationWindow NW = new DimplomApp.WindowsProject.NavigationWindow();
                NW.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверные учетные данные. Попробуйте еще раз.", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
