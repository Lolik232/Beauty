using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using Beauty.WPF.Views;
using Catel.IoC;
using Catel.MVVM;
using Catel.MVVM.Views;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

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

                // Помечаем текущую View'шку, как старую
                oldViewControl.Content = newViewControl.Content;

                if (oldViewControl.Content is BaseView oldView)
                {
                    oldView.ShouldAnimateOut = true; // Уведомляем View'шку, что необходимо проиграть анимацию закрытия

                    var delay = (int)(oldView.AnimationTime * 1000);
                    Task.Delay(delay).ContinueWith(Task => // Ждем, пока анимация проигрывается и затем...
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            // ... заставляем сборщик мусора удалить старую страницу после проигрывания ее анимации
                            oldViewControl.Content = null;
                        });
                    });
                }

                // Устанавливаем новую View'шку в качестве текущей
                newViewControl.Content = currentView;
            }

            return value;
        }
    }
}