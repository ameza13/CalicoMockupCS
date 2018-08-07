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
    class AspectRatioConverter : IValueConverter
    {
        private double _aspectRatio = Settings.Default.workingAreaHeight / Settings.Default.workingAreaWidth;

        //Converts height to width
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (targetType != typeof(double))
                throw new InvalidOperationException("The target must be a double");

            return ((double)value)/_aspectRatio;
        }

        // Converts width to height
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((double)value) * _aspectRatio;
        }
    }
}
