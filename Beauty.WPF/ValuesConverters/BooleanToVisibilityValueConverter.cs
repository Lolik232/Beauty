using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beauty.WPF.ValuesConverters
{
    public class BooleanToVisibilityValueConverter : BaseValueConverter<BooleanToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Visibility)value)
            {
                case Visibility.Visible:
                    return true;

                case Visibility.Hidden:
                    return false;

                default:
                    return false;
            }
        }
    }
}
