using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.ViewModels;
using Beauty.WPF.Views;
using Catel.MVVM.Views;

namespace Beauty.WPF.Extensions
{
    public static class ViewExtensions
    {
        public static IView ToView(this ApplicationViews view, params object[] parameters)
        {
            switch (view)
            {
                case ApplicationViews.LoginView:
                    return Controller.GetView<LoginView>(parameters);

                case ApplicationViews.EnrollmentView:
                    return Controller.GetView<EnrollmentView>(parameters);

                case ApplicationViews.EnrollmentDetailsView:
                    return Controller.GetView<EnrollmentDetailsView>(parameters);

                default:
                    return null;
            }
        }
    }
}
