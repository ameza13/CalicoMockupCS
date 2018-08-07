using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalicoMock.Util
{
    [ValueConversion(typeof(ObservableCollection<string>), typeof(string))]
    public class ListToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a String");

            return String.Join(",", ((ObservableCollection<string>)value).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ObservableCollection<string> allTags = new ObservableCollection<string>();

            foreach (string s in ((string)value).Split(','))
            {
                allTags.Add(s);
            }
            return allTags;
        }
    }
}
