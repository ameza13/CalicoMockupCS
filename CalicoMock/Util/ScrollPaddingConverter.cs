using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CalicoMock.Properties;

namespace CalicoMock.Util
{
    [ValueConversion(typeof(double), typeof(double))]
    class ScrollPaddingConverter : IValueConverter
    {
        private double padding = Settings.Default.scrollPadding;

        //Adds padding to length measure
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (targetType != typeof(double))
                throw new InvalidOperationException("The target must be a double");

            Console.WriteLine(((double)value) * (1.0 + padding));

            return ((double)value)*(1.0 + padding);
        }

        // removes padding from length measure
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((double)value) / (1.0 + padding);
        }
    }
}
