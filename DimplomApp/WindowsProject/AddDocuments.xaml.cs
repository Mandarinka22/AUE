using DimplomApp.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DimplomApp.AddingWindows;

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для AddDocuments.xaml
    /// </summary>
    public partial class AddDocuments : Window
    {
        DiplomaEntities DB;
        private Notaries selectedNotary;
        private int selectedPriceID;
        public int SelectedServiceID;

        public AddDocuments(DiplomaEntities DB, Documents Table)
        {
            InitializeComponent();
            this.DB = DB;
            this.DataContext = Table;
            // Установка текущей даты в поле Date
            ((Documents)this.DataContext).Date = DateTime.Now;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Установить идентификатор нотариуса в свойство NotaryID вашего объекта Documents
            ((Documents)this.DataContext).NotaryID = selectedNotary.ID_notary;

            // Установить идентификатор услуги в свойство PriceID вашего объекта Documents
            ((Documents)this.DataContext).PriceID = selectedPriceID;

            // Установить идентификатор услуги в свойство PriceID вашего объекта Documents
            ((Documents)this.DataContext).Services = SelectedServiceID;

            DB.SaveChanges();
            MessageBox.Show("Документ успешно добавлен!", "Уведомление");
            this.Close();
        }

        private void SelectNotary_PWD(object sender, RoutedEventArgs e)
        {
            // Открыть окно выбора нотариуса
            NotariesSelectionForm notariesForm = new NotariesSelectionForm(DB);
            bool? result = notariesForm.ShowDialog();

            if (result == true)
            {
                // Получить выбранного нотариуса
                selectedNotary = notariesForm.SelectedNotary;
                if (selectedNotary != null)
                {
                    // Установить идентификатор нотариуса в TextBox
                    SelectNotary.Text = selectedNotary.ID_notary.ToString();
                }
            }
        }
        private void SelectPrice_PWD(object sender, MouseButtonEventArgs e)
        {
            // Открыть окно выбора услуги из таблицы Price_list
            PriceSelectionForm priceForm = new PriceSelectionForm(DB);
            bool? result = priceForm.ShowDialog();

            if (result == true)
            {
                // Получить выбранный идентификатор услуги
                selectedPriceID = priceForm.SelectedPriceID;

                // Установить идентификатор услуги в TextBox
                SelectPrice.Text = selectedPriceID.ToString();
            }
        }
        private void SelectService_PWD(object sender, MouseButtonEventArgs e)
        {
            // Открыть окно выбора услуги из таблицы Price_list
            ServiceSelectionForm serviceForm = new ServiceSelectionForm(DB);
            bool? result = serviceForm.ShowDialog();

            if (result == true)
            {
                // Получить выбранный идентификатор услуги
                SelectedServiceID = serviceForm.SelectedServiceID;

                // Установить идентификатор услуги в TextBox
                SelectService.Text = SelectedServiceID.ToString();
            }
        }

        private void SelectNotary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
