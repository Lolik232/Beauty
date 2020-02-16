using Beauty.WPF.Views;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Beauty.WPF.Extensions
{
    public static class ViewAnimationExtensions
    {
        public static async Task SlideAndFadeInFromRight(this BaseView view, float animationTime)
        {
            var storyboard = new Storyboard();

            var contentControl = view.Parent as ContentControl;
            storyboard.AddSlideFromRight(animationTime, contentControl.ActualWidth);
            storyboard.AddFadeIn(animationTime);
            storyboard.Begin(view);

            view.Visibility = Visibility.Visible;

            var milliseconds = (int)(animationTime * 1000);
            await Task.Delay(milliseconds);
        }

        public static async Task SlideAndFadeOutToLeft(this BaseView view, float animationTime)
        {
            var storyboard = new Storyboard();

            var contentControl = view.Parent as ContentControl;
            storyboard.AddSlideToLeft(animationTime, contentControl.ActualWidth);
            storyboard.AddFadeOut(animationTime);
            storyboard.Begin(view);

            view.Visibility = Visibility.Visible;

            var milliseconds = (int)(animationTime * 1000);
            await Task.Delay(milliseconds);
        }
    }
}
