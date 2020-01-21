using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Beauty.WPF.ValuesConverters
{
    public abstract class BaseValueConverter<TConverter> : MarkupExtension, IValueConverter where TConverter : class, new()
    {
        private static TConverter Converter;

        static BaseValueConverter()
        {
            Converter = null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Converter is null)
            {
                Converter = new TConverter();
            }

            return Converter;
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
