using System.Windows;
using System.Windows.Controls;

namespace Beauty.WPF.AttachedProperties
{
    public class HasPasswordAttachedProperty : BaseAttachedProperty<HasPasswordAttachedProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            var passwordBox = sender as PasswordBox;
            SetValue(sender, passwordBox.SecurePassword.Length > 0);
        }
    }
}
