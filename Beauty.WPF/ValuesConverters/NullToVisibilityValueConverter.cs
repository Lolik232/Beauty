using Catel.MVVM.Converters;
using System;
using System.Windows;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class NullToVisibilityValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var condition = value != null;

            if (parameter != null)
            {
                condition = !condition;
            }

            return condition ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
