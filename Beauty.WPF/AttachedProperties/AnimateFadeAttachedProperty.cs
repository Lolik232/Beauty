using Beauty.WPF.Extensions;
using System.Windows;

namespace Beauty.WPF.AttachedProperties
{
    public class AnimateFadeAttachedProperty : BaseAnimationAttachedProperty<AnimateFadeAttachedProperty>
    {
        protected override async void StartAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            var seconds = firstLoad ? 0 : 0.3f;

            if (value)
            {
                await element.FadeInAsync(firstLoad, seconds);
            }
            else
            {
                await element.FadeOutAsync(seconds);
            }
        }
    }
}
