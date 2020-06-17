using Catel.MVVM.Converters;
using System;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class NullToBooleanValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            return value != null;
        }
    }
}
