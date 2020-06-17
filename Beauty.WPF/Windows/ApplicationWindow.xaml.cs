using Beauty.WPF.ViewModels;
using Catel.Windows;
using System;

namespace Beauty.WPF.Windows
{
    public partial class ApplicationWindow : Window
    {
        public ApplicationWindow()
        {
            InitializeComponent();
        }

        private void OnActivated(object sender, EventArgs e)
        {
            if (ViewModel is null)
            {
                return;
            }

            var application = ViewModel as ApplicationViewModel;
            application.IsDimmable = false;
        }

        private void OnDeactivated(object sender, EventArgs e)
        {
            if (ViewModel is null)
            {
                return;
            }

            var application = ViewModel as ApplicationViewModel;
            application.IsDimmable = true;
        }
    }
}