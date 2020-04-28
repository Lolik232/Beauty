using Catel.MVVM.Converters;
using System;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class TimeValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var dateTime = value as DateTime?;

            if (dateTime is null || !dateTime.HasValue)
            {
                return value;
            }

            return dateTime.Value.ToString("HH:mm");
        }
    }
}