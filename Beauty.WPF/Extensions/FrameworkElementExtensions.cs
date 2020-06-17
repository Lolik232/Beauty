using Beauty.WPF.Enums;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Beauty.WPF.Extensions
{
    public static class FrameworkElementExtensions
    {
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, FrameworkElementAnimations direction, bool firstLoad, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            var storyboard = new Storyboard();

            var width = size.Equals(0) ? element.ActualWidth : size;
            var height = size.Equals(0) ? element.ActualHeight : size;

            switch (direction)
            {
                case FrameworkElementAnimations.Left:
                    storyboard.AddSlideFromLeft(seconds, width, keepMargin: keepMargin);
                    break;

                case FrameworkElementAnimations.Right:
                    storyboard.AddSlideFromRight(seconds, width, keepMargin: keepMargin);
                    break;

                case FrameworkElementAnimations.Top:
                    storyboard.AddSlideFromTop(seconds, height, keepMargin: keepMargin);
                    break;

                case FrameworkElementAnimations.Bottom:
                    storyboard.AddSlideFromBottom(seconds, height, keepMargin: keepMargin);
                    break;
            }

            storyboard.AddFadeIn(seconds);

            storyboard.Begin(element);

            if (seconds != 0.0f || firstLoad)
            {
                element.Visibility = Visibility.Visible;
            }

            var delay = (int)(seconds * 1000);
            await Task.Delay(delay);
        }

        public static async Task SlideAndFadeOutAsync(this FrameworkElement element, FrameworkElementAnimations direction, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            var storyboard = new Storyboard();

            var width = size.Equals(0) ? element.ActualWidth : size;
            var height = size.Equals(0) ? element.ActualHeight : size;

            switch (direction)
            {
                case FrameworkElementAnimations.Left:
                    storyboard.AddSlideToLeft(seconds, width, keepMargin: keepMargin);
                    break;

                case FrameworkElementAnimations.Right:
                    storyboard.AddSlideToRight(seconds, width, keepMargin: keepMargin);
                    break;

                case FrameworkElementAnimations.Top:
                    storyboard.AddSlideToTop(seconds, height, keepMargin: keepMargin);
                    break;

                case FrameworkElementAnimations.Bottom:
                    storyboard.AddSlideToBottom(seconds, height, keepMargin: keepMargin);
                    break;
            }

            storyboard.AddFadeOut(seconds);

            storyboard.Begin(element);

            if (seconds != 0.0f)
            {
                element.Visibility = Visibility.Visible;
            }

            var delay = (int)(seconds * 1000);
            await Task.Delay(delay);

            if (Math.Round(element.Opacity).Equals(0.0))
            {
                element.Visibility = Visibility.Hidden;
            }
        }

        public static async Task FadeInAsync(this FrameworkElement element, bool firstLoad, float seconds = 0.3f)
        {
            var storyboard = new Storyboard();

            storyboard.AddFadeIn(seconds);

            storyboard.Begin(element);

            if (seconds != 0.0f || firstLoad)
            {
                element.Visibility = Visibility.Visible;
            }

            var delay = (int)(seconds * 1000);
            await Task.Delay(delay);
        }

        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            var storyboard = new Storyboard();

            storyboard.AddFadeOut(seconds);

            storyboard.Begin(element);

            if (seconds != 0.0f)
            {
                element.Visibility = Visibility.Visible;
            }

            var delay = (int)(seconds * 1000);
            await Task.Delay(delay);

            if (Math.Round(element.Opacity).Equals(0.0))
            {
                element.Visibility = Visibility.Hidden;
            }
        }
    }
}
