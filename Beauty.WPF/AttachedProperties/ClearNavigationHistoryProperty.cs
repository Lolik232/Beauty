using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Beauty.WPF.AttachedProperties
{
    public class ClearNavigationHistoryProperty : BaseProperty<ClearNavigationHistoryProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = sender as Frame;
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frame.Navigated += Navigated;
        }

        private void Navigated(object sender, NavigationEventArgs e)
        {
            var frame = sender as Frame;
            frame.NavigationService.RemoveBackEntry();
        }
    }
}
