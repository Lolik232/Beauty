using Catel.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Beauty.WPF.AttachedProperties
{
    public class ChildrenPaddingAttachedProperty : BaseAttachedProperty<ChildrenPaddingAttachedProperty, Thickness>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is null)
            {
                return;
            }

            var panel = sender as Panel;
            var childrens = panel.Children;

            if (!panel.IsLoaded)
            {
                panel.Loaded += OnPanelLoaded;
            }
        }

        private void OnPanelLoaded(object sender, RoutedEventArgs e)
        {
            var dependencyObject = sender as DependencyObject;
            var value = GetValue(dependencyObject);
            
            var panel = sender as Panel;

            foreach (var children in panel.Children)
            {
                var frameworkElement = children as FrameworkElement;
                frameworkElement.Margin = value;
            }
        }
    }
}
