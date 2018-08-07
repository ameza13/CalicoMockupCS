using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalicoMock.Util
{
    class ColumnConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double itemwidth = (double)values[0] * 1024.0 / 768.0;
            double availableWidth = (double)values[1];
            double columnCount = Math.Max(Math.Truncate(availableWidth / itemwidth),1);

            return (Int32)columnCount;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
