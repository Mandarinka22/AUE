using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DimplomApp.DataBase;
using DimplomApp.WindowsProject;
using DimplomApp.AddingWindows;
using System.Windows;

namespace DimplomApp
{
    public class NullableDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return date.Date.ToString("dd.MM.yyyy");
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string dateString)
            {
                if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", culture, DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
