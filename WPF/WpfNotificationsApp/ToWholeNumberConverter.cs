using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfNotificationsApp
{
    public class ToWholeNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => System.Convert.ToInt32((double)value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (double)value;
    }
}
