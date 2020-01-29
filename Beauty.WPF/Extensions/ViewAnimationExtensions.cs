using Beauty.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            storyboard.AddSlideFromRight(animationTime, view.WindowWidth);
            storyboard.AddFadeIn(animationTime);
            storyboard.Begin(view);

            view.Visibility = Visibility.Visible;

            var milliseconds = (int)(animationTime * 1000);
            await Task.Delay(milliseconds);
        }

        public static async Task SlideAndFadeOutToLeft(this BaseView view, float animationTime)
        {
            var storyboard = new Storyboard();

            storyboard.AddSlideToLeft(animationTime, view.WindowWidth);
            storyboard.AddFadeOut(animationTime);
            storyboard.Begin(view);

            view.Visibility = Visibility.Visible;

            var milliseconds = (int)(animationTime * 1000);
            await Task.Delay(milliseconds);
        }
    }
}
