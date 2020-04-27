using Beauty.WPF.ViewModels;
using Catel.Windows;
using System;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Beauty.WPF.Windows
{
    public partial class EnrollmentDetailsWindow : Window
    {
        public EnrollmentDetailsWindow()
        {
            InitializeComponent();
        }

        private void OnClientPhoneNumberChanged(object sender, EventArgs e)
        {
            if (ViewModel is null)
            {
                return;
            }

            var maskedTextBox = sender as MaskedTextBox;
            var enrollmentDetails = ViewModel as EnrollmentDetailsViewModel;
            enrollmentDetails.IsClientPhoneNumberFilled = maskedTextBox.IsMaskFull;
        }

        private void OnTimeChanged(object sender, EventArgs e)
        {
            if (ViewModel is null)
            {
                return;
            }

            var maskedTextBox = sender as MaskedTextBox;
            var enrollmentDetails = ViewModel as EnrollmentDetailsViewModel;
            enrollmentDetails.IsTimeFilled = maskedTextBox.IsMaskFull;
        }
    }
}
