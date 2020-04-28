using Catel.MVVM.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class DateValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var dateTime = value as DateTime?;

            if (dateTime is null || !dateTime.HasValue)
            {
                return value;
            }

            var day = dateTime.Value.ToString("dd MMMM");

            if (!DateTime.Now.Date.Year.Equals(dateTime.Value.Year))
            {
                day += $" {dateTime.Value.Year} г.";
            }
            else if (DateTime.Now.Date.CompareTo(dateTime.Value.Date).Equals(0))
            {
                day = "Сегодня";
            }
            else if (DateTime.Now.Date.AddDays(-1).CompareTo(dateTime.Value.Date).Equals(0))
            {
                day = "Вчера";
            }

            return dateTime.Value.ToString(day);
        }
    }
}
