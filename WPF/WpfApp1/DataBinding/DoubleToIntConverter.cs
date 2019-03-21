using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Globalization;

namespace WpfApp1.DataBinding
{
    public class DoubleToIntConverter : IValueConverter
    {

        public DoubleToIntConverter()
        {

        }
        static DoubleToIntConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var d = (double)value;
            return (int)d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var i = (int)value;
            return (double)i;
        }
    }
}
