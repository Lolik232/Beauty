using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using Beauty.WPF.Views;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Beauty.WPF.Controls
{
    /// <summary>
    /// Элемент управления, описывающий постраничную навигацию
    /// </summary>
    public partial class ViewHost : UserControl
    {
        /// <summary>
        /// Текущая страница, отображаемая в окне приложения
        /// </summary>
        public ApplicationViews View
        {
            get => (ApplicationViews)GetValue(ViewProperty);
            set => SetValue(ViewProperty, value);
        }

        public object[] ViewParameters
        {
            get => (object[])GetValue(ViewParametersProperty);
            set => SetValue(ViewParametersProperty, value);
        }

        /// <summary>
        /// Свойство зависимости для <see cref="View"/>
        /// </summary>
        public static readonly DependencyProperty ViewProperty = DependencyProperty.Register(
           nameof(View),
           typeof(ApplicationViews),
           typeof(ViewHost),
           new UIPropertyMetadata
           (
               default(ApplicationViews),
               null,
               OnViewChanged
           )
        );

        public static readonly DependencyProperty ViewParametersProperty = DependencyProperty.Register(
           nameof(ViewParameters),
           typeof(object[]),
           typeof(ViewHost),
           new UIPropertyMetadata(
               default(object[]), 
               null,
               OnViewParametersChanged
           )
        );

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public ViewHost()
        {
            InitializeComponent();
        }

        private static object OnViewParametersChanged(DependencyObject dependencyObject, object value)
        {
            var newValue = (object[])value;

            var viewHost = dependencyObject as ViewHost;

            viewHost.Tag = newValue;

            return value;
        }

        /// <summary>
        /// Событие, возникающее при изменении свойства <see cref="View"/>
        /// </summary>
        /// <param name="dependencyObject">Объект-родитель для дочерних элементов управления</param>
        /// <param name="value">Новое значение для элемента управления</param>
        /// <returns></returns>
        private static object OnViewChanged(DependencyObject dependencyObject, object value)
        {
            var newViewValue = (ApplicationViews)value;

            if (newViewValue.Equals(ApplicationViews.None))
            {
                return value;
            }

            var viewHost = dependencyObject as ViewHost;

            var currentView = newViewValue.ToView((object[])viewHost.Tag);

            var oldViewControl = viewHost.OldView;
            var newViewControl = viewHost.NewView;

            var oldViewContent = newViewControl.Content;
            newViewControl.Content = null;
            oldViewControl.Content = oldViewContent;

            if (oldViewContent is BaseView oldView)
            {
                oldView.ShouldAnimateOut = true;

                Task.Delay((int)(oldView.AnimationTime * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldViewControl.Content = null);
                });
            }

            newViewControl.Content = currentView;

            return value;
        }
    }
}