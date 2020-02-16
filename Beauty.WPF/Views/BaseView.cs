using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using Catel.Services;
using Catel.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace Beauty.WPF.Views
{
    public class BaseView : UserControl
    {
        public ViewAnimations ViewLoadAnimation { get; set; }
        public ViewAnimations ViewUnloadAnimation { get; set; }
        public bool ShouldAnimateOut { get; set; }
        public float AnimationTime { get; set; }

        public BaseView()
        {
            ViewLoadAnimation = ViewAnimations.SlideAndFadeInFromRight;
            ViewUnloadAnimation = ViewAnimations.SlideAndFadeOutToLeft;
            AnimationTime = 0.8f;

            if (ViewLoadAnimation != ViewAnimations.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += ViewLoaded;
        }

        public async Task AnimateInAsync()
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

        public async Task AnimateOutAsync()
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

        private async void ViewLoaded(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
            {
                await AnimateOutAsync();
            }
            else
            {
                await AnimateInAsync();
            }
        }
    }
}