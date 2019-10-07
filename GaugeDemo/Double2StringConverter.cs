using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GaugeDemo
{
    [ValueConversion(typeof(double), typeof(string))]
    class Double2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "-";

            double dVal = (double)value;
            return dVal == Double.NaN ? "-" : string.Format("{0:F1}", dVal);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
