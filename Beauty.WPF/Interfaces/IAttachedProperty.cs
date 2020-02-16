using System;
using System.Windows;

namespace Beauty.WPF.Interfaces
{
    public interface IAttachedProperty
    {
        event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged;
        event Action<DependencyObject, object> ValueUpdated;
        void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e);
        void OnValueUpdated(DependencyObject sender, object value);
    }
}