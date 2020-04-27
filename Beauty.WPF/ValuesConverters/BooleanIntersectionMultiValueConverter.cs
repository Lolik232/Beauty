using Catel.Collections;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Beauty.WPF.ValuesConverters
{
    public class BooleanIntersectionMultiValueConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var condition = default(bool);

            foreach (var value in values)
            {
                var boolValue = value as bool?;

                if (boolValue ?? false)
                {
                    condition = true;
                }
                else
                {
                    condition = false;
                    break;
                }
            }

            if (parameter != null)
            {
                condition = !condition;
            }

            return condition;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
