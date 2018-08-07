using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalicoMock.Util
{
    [ValueConversion(typeof(double), typeof(int))]
    class PercentConverter : IValueConverter
    {
        private const double _aspectRatio = 768.0 / 1024;

        //Converts 0.05 to 5
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToDouble(value) * 100;
        }

        // 5 to 0.05
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToDouble(value) / 100.0;
        }
    }
}
