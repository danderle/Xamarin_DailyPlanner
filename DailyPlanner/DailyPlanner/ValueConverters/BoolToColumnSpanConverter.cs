using System;
using System.Globalization;

namespace DailyPlanner
{
    /// <summary>
    /// Converts a bool to a ColumnSpan
    /// </summary>
    public class BoolToColumnSpan : BaseValueConverter<BoolToColumnSpan>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            bool _value = (bool)value;
            return _value ? "2" : "1";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
