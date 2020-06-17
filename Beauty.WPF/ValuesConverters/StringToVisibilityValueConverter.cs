using Catel.MVVM.Converters;
using System;
using System.Security;
using System.Windows;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class StringToVisibilityValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var condition = !string.IsNullOrEmpty(value as string);

            if (parameter != null)
            {
                condition = !condition;
            }

            return condition ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
