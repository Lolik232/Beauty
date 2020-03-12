using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Beauty.WPF.Extensions
{
    public static class StoryboardExtensions
    {
        public static void AddSlideFromRight(this Storyboard storyboard, float animationTime, double offset, float decelerationRatio = 0.9f)
        {
            var timeSpan = TimeSpan.FromSeconds(animationTime);

            var animation = new ThicknessAnimation
            {
                Duration = new Duration(timeSpan),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            var path = new PropertyPath("Margin");
            Storyboard.SetTargetProperty(animation, path);

            storyboard.Children.Add(animation);
        }

        public static void AddSlideToLeft(this Storyboard storyboard, float animationTime, double offset, float decelerationRatio = 0.9f)
        {
            var timeSpan = TimeSpan.FromSeconds(animationTime);

            var animation = new ThicknessAnimation
            {
                Duration = new Duration(timeSpan),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            var path = new PropertyPath("Margin");
            Storyboard.SetTargetProperty(animation, path);

            storyboard.Children.Add(animation);
        }

        public static void AddFadeIn(this Storyboard storyboard, float animationTime)
        {
            var timeSpan = TimeSpan.FromSeconds(animationTime);

            var animation = new DoubleAnimation
            {
                Duration = new Duration(timeSpan),
                From = 0,
                To = 1,
            };

            var path = new PropertyPath("Opacity");
            Storyboard.SetTargetProperty(animation, path);

            storyboard.Children.Add(animation);
        }

        public static void AddFadeOut(this Storyboard storyboard, float animationTime)
        {
            var timeSpan = TimeSpan.FromSeconds(animationTime);

            var animation = new DoubleAnimation
            {
                Duration = new Duration(timeSpan),
                From = 1,
                To = 0,
            };

            var path = new PropertyPath("Opacity");
            Storyboard.SetTargetProperty(animation, path);

            storyboard.Children.Add(animation);
        }

    }
}
