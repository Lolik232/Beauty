using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Beauty.WPF.AttachedProperties
{
    public abstract class BaseAnimationAttachedProperty<Parent> : BaseAttachedProperty<Parent, bool> where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        protected Dictionary<WeakReference, bool> alreadyLoaded = new Dictionary<WeakReference, bool>();
        protected Dictionary<WeakReference, bool> firstLoadValue = new Dictionary<WeakReference, bool>();

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
            {
                return;
            }

            var alreadyLoadedReference = alreadyLoaded.FirstOrDefault(KeyValuePair => KeyValuePair.Key.Target?.Equals(sender) ?? false);
            var firstLoadReference = firstLoadValue.FirstOrDefault(KeyValuePair => KeyValuePair.Key.Target?.Equals(sender) ?? false);

            if (sender.GetValue(ValueProperty).Equals((bool)value) && alreadyLoadedReference.Key != null)
            {
                return;
            }

            if (alreadyLoadedReference.Key is null)
            {
                var target = new WeakReference(sender);

                alreadyLoaded[target] = false;

                element.Visibility = Visibility.Hidden;

                var onLoaded = default(RoutedEventHandler);

                onLoaded = async (parameter, tag) =>
                {
                    element.Loaded -= onLoaded;

                    await Task.Delay(5);

                    firstLoadReference = firstLoadValue.FirstOrDefault(KeyValuePair => KeyValuePair.Key.Target?.Equals(sender) ?? false);

                    StartAnimation(element, firstLoadReference.Key != null ? firstLoadReference.Value : (bool)value, true);

                    alreadyLoaded[target] = true;
                };

                element.Loaded += onLoaded;
            }
            else if (!alreadyLoadedReference.Value)
            {
                var target = new WeakReference(sender);
                firstLoadValue[target] = (bool)value;
            }
            else
            {
                StartAnimation(element, (bool)value, false);
            }
        }

        protected abstract void StartAnimation(FrameworkElement element, bool value, bool firstLoad);
    }
}
