using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Beauty.WPF.AttachedProperties
{
    public class ListenPasswordChangesProperty : BaseAttachedProperty<ListenPasswordChangesProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;

            if (passwordBox is null)
            {
                return;
            }

            passwordBox.PasswordChanged -= PasswordChanged;

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;

            HasTextProperty.SetValue(passwordBox);
        }
    }

    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
       {
            var passwordBox = sender as PasswordBox;

            SetValue(sender, passwordBox.SecurePassword.Length > 0);
        }
    }
}
