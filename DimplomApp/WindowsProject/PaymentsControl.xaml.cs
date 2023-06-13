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
using static System.Windows.MessageBox;

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для PaymentsControl.xaml
    /// </summary>
    public partial class PaymentsControl : UserControl
    {
        DiplomaEntities DB;
        List<Payments> TB;
        public PaymentsControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();
            TB = DB.Payments.ToList();

            var payments = DB.Payments.ToList();


            // Получите список всех услуг из таблицы Services_client
            var services = DB.Services_client.ToList();

            // Получите список новых услуг, которых нет в таблице Payments
            var newServices = services.Where(s => !payments.Any(p => p.ServicesID == s.ID)).ToList();

            // Добавьте новые услуги в таблицу Payments
            foreach (var service in newServices)
            {
                var newPayment = new Payments
                {
                    ServicesID = service.ID
                };

                DB.Payments.Add(newPayment);
            }

            // Сохраните изменения в базе данных
            DB.SaveChanges();

            // Обновите источник данных для TableGrid, чтобы отобразить новые услуги
            TableGrid.ItemsSource = DB.Payments.ToList();

            foreach (var payment in payments)
            {
                // Находим все документы, связанные с услугой данного платежа
                var documents = DB.Documents.Where(d => d.Services == payment.ServicesID).ToList();

                // Вычисляем сумму документов
                var totalAmount = documents.Sum(d => d.Price_list.Sum);

                // Сохраняем сумму в поле Sum платежа
                payment.Sum = totalAmount;
            }

            foreach (var payment in payments)
            {
                var documents = DB.Documents.Where(d => d.Services == payment.ServicesID).ToList();

                // Проверяем, что есть хотя бы один документ
                if (documents.Any())
                {
                    // Устанавливаем дату первого документа в поле Date_payments
                    payment.Date_payments = documents.First().Date;
                }
            }

            // Сохраняем изменения в базе данных
            DB.SaveChanges();

            TableGrid.ItemsSource = payments;

        }
        private void refreshdatagrid()
        {
            TableGrid.ItemsSource = DB.Payments.ToList();
            TableGrid.Items.Refresh();
        }
        private void EditDescription_Click(object sender, RoutedEventArgs e)
        {
            var selectedPayment = (Payments)TableGrid.SelectedItem;

            if (selectedPayment != null)
            {
                // Создание и отображение диалогового окна для ввода описания
                var descriptionDialog = new DescriptionDialog();
                var result = descriptionDialog.ShowDialog();

                // Проверка результата диалогового окна
                if (result == true)
                {
                    // Получение введенного описания из диалогового окна
                    var description = descriptionDialog.Description;

                    // Проверка, что пользователь ввел описание
                    if (!string.IsNullOrEmpty(description))
                    {
                        // Присваивание введенного описания выбранной строке
                        selectedPayment.Description = description;

                        // Сохранение изменений в базе данных
                        DB.SaveChanges();
                        refreshdatagrid();
                    }
                    else
                    {
                        // Отображение сообщения об ошибке, если описание не было введено
                        MessageBox.Show("Описание не может быть пустым.", "Ошибка");
                    }
                }
            }
            
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            refreshdatagrid();
        }
    }
}
