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
            get => (ApplicationViews)GetValue(CurrentViewProperty);

            set => SetValue(CurrentViewProperty, value);
        }

        /// <summary>
        /// Свойство зависимости для <see cref="View"/>
        /// </summary>
        public static readonly DependencyProperty CurrentViewProperty = DependencyProperty.Register(
           nameof(View),
           typeof(ApplicationViews),
           typeof(ViewHost),
           new UIPropertyMetadata(default(ApplicationViews),
               null,
               OnViewChanged
           )
        );

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public ViewHost()
        {
            InitializeComponent();
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

            var currentView = newViewValue.ToView();

            var viewHost = dependencyObject as ViewHost;

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