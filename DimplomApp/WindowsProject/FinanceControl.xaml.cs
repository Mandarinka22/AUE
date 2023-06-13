using DimplomApp.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
using System.Diagnostics;

namespace DimplomApp.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для FinanceControl.xaml
    /// </summary>
    public partial class FinanceControl : UserControl
    {
        DiplomaEntities DB;
        private IQueryable<Finance> TB;

        public FinanceControl()
        {
            InitializeComponent();
            DB = new DiplomaEntities();

            // Получение данных из таблицы Expenses и добавление их в список Finance
            var expenseData = DB.Expenses.ToList();
            var expenses = expenseData.Select(expense => new Finance
            {
                ExpensesID = expense.ID_expenses,
                Sum = expense.Sum,
                Type_of_OperationID = 2, // Установка типа операции для трат (2 - траты)
                Date = expense.Date_expenses
            });

            // Получение данных из таблицы Payments и добавление их в список Finance
            var paymentData = DB.Payments.ToList();
            var payments = paymentData.Select(payment => new Finance
            {
                PaymentID = payment.ID_payments,
                Sum = payment.Sum,
                Type_of_OperationID = 1, // Установка типа операции для прибыли (1 - прибыль)
                Date = payment.Date_payments
            });

            // Объединение данных из обоих списков
            TB = expenses.Union(payments).ToList().AsQueryable();

            // Выполнение объединения (join) с таблицей Type_of_operation для получения текстового представления типа операции
            var operationData = DB.Type_of_operation.ToList();
            TB = TB
                .Join(operationData,
                      finance => finance.Type_of_OperationID,
                      operation => operation.ID_type,
                      (finance, operation) => new Finance
                      {
                          ID_finance = finance.ID_finance,
                          Sum = finance.Sum,
                          Type_of_OperationID = finance.Type_of_OperationID,
                          OperationType = operation.Operation,
                          Date = finance.Date
                      })
                .OrderByDescending(finance => finance.Date) // Сортировка по убыванию даты
                .ToList().AsQueryable();

            foreach (var financeItem in TB.Where(item => item.Type_of_OperationID == 2))
            {
                var expense = DB.Expenses.FirstOrDefault(e => e.ID_expenses == financeItem.ExpensesID);
                if (expense != null)
                {
                    expense.Sum = financeItem.Sum;
                    DB.Entry(expense).State = EntityState.Modified; // Пометить объект как измененный
                }
            }

            foreach (var financeItem in TB.Where(item => item.Type_of_OperationID == 1))
            {
                var payment = DB.Payments.FirstOrDefault(p => p.ID_payments == financeItem.PaymentID);
                if (payment != null)
                {
                    payment.Sum = financeItem.Sum;
                    DB.Entry(payment).State = EntityState.Modified; // Пометить объект как измененный
                }
            }
            // Сохранение изменений в базе данных
            DB.SaveChanges();
            // Заполнение DataGrid данными из списка Finance
            FinanceGrid.ItemsSource = TB.ToList();

            // Выполнение пересчета и обновление сумм
            UpdateSummary(); 
        }

        private void UpdateSummary()
        {
            var financeRecords = FinanceGrid.ItemsSource as List<Finance>;

            if (financeRecords != null)
            {
                decimal profitSum = financeRecords.Where(r => r.Type_of_OperationID == 1).Sum(r => r.Sum ?? 0);
                decimal expenseSum = financeRecords.Where(r => r.Type_of_OperationID == 2).Sum(r => r.Sum ?? 0);
                decimal netProfit = profitSum - expenseSum;

                IncomeLabel.Content = profitSum.ToString();
                ExpenseLabel.Content = expenseSum.ToString();
                NetIncomeLabel.Content = netProfit.ToString();
            }
            else
            {
                IncomeLabel.Content = string.Empty;
                ExpenseLabel.Content = string.Empty;
                NetIncomeLabel.Content = string.Empty;
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
            UpdateSummary();
        }

        private void UpdateDataGrid()
        {
            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;

            if (startDate.HasValue && endDate.HasValue)
            {
                DateTime start = startDate.Value.Date;
                DateTime end = endDate.Value.Date.AddDays(1).AddMilliseconds(-1);

                var financeRecords = TB.Where(r => r.Date >= start && r.Date <= end).OrderBy(r => r.Date).ToList();
                FinanceGrid.ItemsSource = financeRecords;
            }
            else
            {
                FinanceGrid.ItemsSource = null;
            }
        }

        private void ClearDatePicker_Click(object sender, RoutedEventArgs e)
        {
            // Сброс выбранных дат в DatePicker
            StartDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;

            // Очистка фильтрации и обновление DataGrid
            FinanceGrid.ItemsSource = TB.ToList();

            // Выполнение пересчета и обновление сумм
            UpdateSummary();
        }
    }
}
