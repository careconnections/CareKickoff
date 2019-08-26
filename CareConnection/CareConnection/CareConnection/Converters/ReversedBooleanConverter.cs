using System;
using System.Globalization;
using Xamarin.Forms;

namespace CareConnection.Core.Converters
{
    public class ReversedBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}