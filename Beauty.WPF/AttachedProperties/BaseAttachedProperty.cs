using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beauty.WPF.AttachedProperties
{
    public abstract class BaseAttachedProperty<TParent, TProperty> where TParent : new()
    {
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        public static TParent Instance { get; private set; } = new TParent();

        public static readonly UIPropertyMetadata MetadataProperty = new UIPropertyMetadata(
            default(TProperty),
            new PropertyChangedCallback(OnValuePropertyChanged),
            new CoerceValueCallback(OnValuePropertyUpdated)
        );

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(TProperty),
            typeof(BaseAttachedProperty<TParent, TProperty>),
            MetadataProperty
        );

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        { }

        public virtual void OnValueUpdated(DependencyObject sender, object value)
        { }

        private static void OnValuePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<TParent, TProperty>)?.OnValueChanged(dependencyObject, e);

            (Instance as BaseAttachedProperty<TParent, TProperty>)?.ValueChanged(dependencyObject, e);
        }

        private static object OnValuePropertyUpdated(DependencyObject dependencyObject, object value)
        {
            (Instance as BaseAttachedProperty<TParent, TProperty>)?.OnValueUpdated(dependencyObject, value);

            (Instance as BaseAttachedProperty<TParent, TProperty>)?.ValueUpdated(dependencyObject, value);

            return value;
        }

        public static TProperty GetValue(DependencyObject dependencyObject) => (TProperty)dependencyObject.GetValue(ValueProperty);

        public static void SetValue(DependencyObject dependencyObject, TProperty value) => dependencyObject.SetValue(ValueProperty, value);
    }
}
