using Catel.MVVM.Converters;
using System;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Beauty.WPF.ValuesConverters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class TaskToBooleanValueConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var task = (Task)value;
            var condition = task != null && task.IsCompleted;

            if (parameter != null)
            {
                condition = !condition;
            }

            return condition;
        }
    }
}
