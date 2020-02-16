using Catel.MVVM.Converters;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class BooleanToVisibilityValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var visibility = Visibility.Collapsed;

            if (parameter is null)
            {
                visibility = (bool)value ? Visibility.Visible : Visibility.Hidden;
            }
            else
            {
                visibility = (bool)value ? Visibility.Hidden : Visibility.Visible;
            }

            return visibility;
        }
    }
}
