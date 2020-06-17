using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using Catel.Windows.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Beauty.WPF.Views
{
    public class BaseView : UserControl
    {
        public ViewAnimations ViewLoadAnimation { get; set; }
        public ViewAnimations ViewUnloadAnimation { get; set; }
        public float AnimationTime { get; set; }

        public bool ShouldAnimateOut
        {
            get => (bool)GetValue(ShouldAnimateOutProperty);
            set => SetValue(ShouldAnimateOutProperty, value);
        }

        public static readonly DependencyProperty ShouldAnimateOutProperty = DependencyProperty.Register(
            nameof(ShouldAnimateOut),
            typeof(bool),
            typeof(BaseView),
            new UIPropertyMetadata
            (
                default(bool),
                null,
                OnShouldAnimateOutPropertyChanged
            )
        );

        public event RoutedEventHandler AnimateOutHandler;

        public BaseView()
        {
            ViewLoadAnimation = ViewAnimations.SlideAndFadeInFromRight;
            ViewUnloadAnimation = ViewAnimations.SlideAndFadeOutToLeft;
            AnimationTime = 0.8f;

            if (ViewLoadAnimation != ViewAnimations.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += OnViewLoaded;
            AnimateOutHandler += OnAnimateOutExecuteAsync;
        }

        private async Task AnimateInAsync()
        {
            switch (ViewLoadAnimation)
            {
                case ViewAnimations.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(AnimationTime);
                    return;

                case ViewAnimations.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(AnimationTime);
                    return;
            }
        }

        private async Task AnimateOutAsync()
        {
            switch (ViewUnloadAnimation)
            {
                case ViewAnimations.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(AnimationTime);
                    return;

                case ViewAnimations.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(AnimationTime);
                    return;
            }
        }

        private async void OnViewLoaded(object sender, RoutedEventArgs e)
        {
            await AnimateInAsync();
        }

        private async void OnAnimateOutExecuteAsync(object sender, RoutedEventArgs e)
        {
            await AnimateOutAsync();
        }

        private static object OnShouldAnimateOutPropertyChanged(DependencyObject dependencyObject, object value)
        {
            var view = dependencyObject as BaseView;

            if ((bool)value)
            {
                var eventArgs = EventArgs.Empty as RoutedEventArgs;
                view.AnimateOutHandler?.Invoke(view, eventArgs);
            }

            return value;
        }
    }
}