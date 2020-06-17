using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using System.Windows;

namespace Beauty.WPF.AttachedProperties
{
    public class AnimateSlideInFromTopAttachedProperty : BaseAnimationAttachedProperty<AnimateSlideInFromTopAttachedProperty>
    {
        protected override async void StartAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            var seconds = firstLoad ? 0 : 0.3f;

            if (value)
            {
                await element.SlideAndFadeInAsync(FrameworkElementAnimations.Top, firstLoad, seconds, keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutAsync(FrameworkElementAnimations.Top, seconds, keepMargin: false);
            }
        }
    }
}
