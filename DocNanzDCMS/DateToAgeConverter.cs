using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DocNanzDCMS
{
    public class DateToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;
            int age = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now.Month < dateTime.Month || (DateTime.Now.Month == dateTime.Month && DateTime.Now.Day < dateTime.Day))
            {
                age--;
            }
            return age;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
