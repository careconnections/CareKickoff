using System;
using System.Globalization;
using Xamarin.Forms;

namespace CareConnection.Core.Converters
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int i = (int)value;
            if (i.Equals(0))
                return string.Empty;
            else
                return i.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty((string)value))
            {
                int employeeId = 0;
                bool isNumber = int.TryParse((string)value, out employeeId);
                return employeeId;
            }
            else
                return 0;
        }
    }
}