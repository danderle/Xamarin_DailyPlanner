using System;
using System.Globalization;

namespace DailyPlanner
{
    /// <summary>
    /// Converts a bool to a ColumnDefinitions
    /// </summary>
    public class BoolToColumn : BaseValueConverter<BoolToColumn>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            bool _value = (bool)value;
            return _value ? "3" : "2";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
