using System;
using System.Windows;
using System.Windows.Data;

namespace Beetle.Converters
{
    public class WhichDieToShowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || targetType == null)
                return Visibility.Collapsed;

            int realParameter, realValue;
            if (Int32.TryParse(value.ToString(), out realValue) && Int32.TryParse(parameter.ToString(), out realParameter))
                return realParameter == realValue ? Visibility.Visible : Visibility.Collapsed;
            else
                throw new Exception(String.Format("Invalid parameter values: {0}, {1}", value, parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}