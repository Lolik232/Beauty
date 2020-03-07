using Beauty.WPF.Enums;
using Beauty.WPF.ViewModels;
using Catel.MVVM;

namespace Beauty.WPF.Extensions
{
    public static class ViewExtensions
    {
        public static IViewModel ToViewModel(this ApplicationViews view)
        {
            switch (view)
            {
                case ApplicationViews.LoginView:
                    return new LoginViewModel();

                case ApplicationViews.EnrollmentsView:
                    return new EnrollmentsViewModel();

                default:
                    return null;
            }
        }
    }
}
