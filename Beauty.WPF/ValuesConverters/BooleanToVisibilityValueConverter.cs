using Catel.MVVM.Converters;
using System;
using System.Windows;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class BooleanToVisibilityValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var condition = (bool)value;

            if (parameter is null)
            {
                condition = !condition;
            }

            return condition ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
