using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CaseApp.Converters
{
    class ObjectNotNullConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !Equals(value, null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
