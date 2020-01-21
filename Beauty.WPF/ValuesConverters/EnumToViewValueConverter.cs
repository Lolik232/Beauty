using Beauty.WPF.Enums;
using Beauty.WPF.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Beauty.WPF.ValuesConverters
{
    public class EnumToViewValueConverter : BaseValueConverter<EnumToViewValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationViews)value)
            {
                case ApplicationViews.LoginView:
                    return new LoginView();

                case ApplicationViews.MainView:
                    return new MainView();

                default:
                    /* Debugger.Stop(); */
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
