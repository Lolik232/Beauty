using Beauty.WPF.Enums;
using Beauty.WPF.ViewModels;
using Beauty.WPF.Views;
using Catel.MVVM.Views;

namespace Beauty.WPF.Extensions
{
    public static class ViewExtensions
    {
        public static IView ToView(this ApplicationViews view)
        {
            switch (view)
            {
                case ApplicationViews.LoginView:
                    return new LoginView();

                case ApplicationViews.EnrollmentView:
                    return new EnrollmentsView();

                case ApplicationViews.ProfileView:
                    return new ProfileView();

                case ApplicationViews.SettingsView:
                    return new SettingsView();

                default:
                    return null;
            }
        }
    }
}
