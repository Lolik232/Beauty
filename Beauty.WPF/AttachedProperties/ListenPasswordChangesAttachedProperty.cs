using System.Windows;
using System.Windows.Controls;

namespace Beauty.WPF.AttachedProperties
{
    public class ListenPasswordChangesAttachedProperty : BaseAttachedProperty<ListenPasswordChangesAttachedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is null)
            {
                return;
            }

            var passwordBox = sender as PasswordBox;

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += OnPasswordChanged;
            }
            else
            {
                passwordBox.PasswordChanged -= OnPasswordChanged;
            }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            HasPasswordAttachedProperty.SetValue(passwordBox);
        }
    }
}
