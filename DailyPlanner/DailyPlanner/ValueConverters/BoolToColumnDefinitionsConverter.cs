using System;
using System.Globalization;

namespace DailyPlanner
{
    /// <summary>
    /// Converts a bool to a ColumnDefinitions
    /// </summary>
    public class BoolToColumnDefinitions : BaseValueConverter<BoolToColumnDefinitions>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            bool _value = (bool)value;
            return _value ? "*,*,*,*" : "*,*,*";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
