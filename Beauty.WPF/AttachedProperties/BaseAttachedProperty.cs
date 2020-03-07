using Beauty.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beauty.WPF.AttachedProperties
{
    /// <summary>
    /// Базовый абстрактный класс для прикрепляемых свойств
    /// </summary>
    /// <typeparam name="TParent">Тип класса, представляющий прикрепляемое свойство</typeparam>
    /// <typeparam name="TProperty">Тип прикрепляемого свойства</typeparam>
    public abstract class BaseAttachedProperty<TParent, TProperty> : IAttachedProperty where TParent : new()
    {
        /// <summary>
        /// Событие, возникающее при изменении значения <see cref="ValueProperty"/>
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// Событие, возникающее при обновлении значения <see cref="ValueProperty"/>
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        /// <summary>
        /// Экземпляр класса, представляющий прикрепляемое свойство
        /// </summary>
        public static TParent Instance { get; private set; } = new TParent();

        /// <summary>
        /// Метаданные для <see cref="ValueProperty"/>
        /// </summary>
        public static readonly UIPropertyMetadata MetadataProperty = new UIPropertyMetadata(
            default(TProperty),
            new PropertyChangedCallback(OnValuePropertyChanged),
            new CoerceValueCallback(OnValuePropertyUpdated)
        );

        /// <summary>
        /// Прикрепляемое свойство
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(TProperty),
            typeof(BaseAttachedProperty<TParent, TProperty>),
            MetadataProperty
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Объект, к которому привязано прикрепляемое свойство</param>
        /// <param name="e"></param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
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
