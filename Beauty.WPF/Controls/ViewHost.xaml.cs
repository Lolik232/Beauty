using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using Beauty.WPF.Views;
using Catel.IoC;
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
                OnViewPropertyChanged
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
        private static object OnViewPropertyChanged(DependencyObject dependencyObject, object value)
        {
            var applicationView = (ApplicationViews)value;

            if (!applicationView.Equals(ApplicationViews.None))
            {
                var viewHost = dependencyObject as ViewHost;

                var currentView = applicationView.ToView();

                var oldViewControl = viewHost.oldView;
                var newViewControl = viewHost.newView;

                var oldViewContent = newViewControl.Content;
                newViewControl.Content = null;
                oldViewControl.Content = oldViewContent;

                if (oldViewContent is BaseView oldView)
                {
                    oldView.ShouldAnimateOut = true;

                    var delay = (int)(oldView.AnimationTime * 1000);
                    Task.Delay(delay).ContinueWith((task) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            oldViewControl.Content = null;
                        });
                    });
                }

                newViewControl.Content = currentView;
            }

            return value;
        }
    }
}