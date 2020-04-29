using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using System.Windows;

namespace Beauty.WPF.AttachedProperties
{
    public class AnimateSlideInFromLeftAttachedProperty : BaseAnimationAttachedProperty<AnimateSlideInFromLeftAttachedProperty>
    {
        protected override async void StartAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
            {
                await element.SlideAndFadeInAsync(FrameworkElementAnimations.Left, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutAsync(FrameworkElementAnimations.Left, firstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }
}
