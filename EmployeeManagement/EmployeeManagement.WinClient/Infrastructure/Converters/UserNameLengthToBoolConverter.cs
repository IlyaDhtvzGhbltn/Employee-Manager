using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace EmployeeManagement.WinClient.Infrastructure.Converters
{
    class UserNameLengthToBoolConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach(var str in values) 
            {
                string input = (string)str;
                if (input.Length < 3)
                {
                    return false;
                }
            }
            return true;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = (string)value;
            if (input.Length < 3)
            {
                return false;
            }
            else return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
