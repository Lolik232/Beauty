using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
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
                    return Controller.GetView<LoginView>();

                case ApplicationViews.EnrollmentView:
                    return Controller.GetView<EnrollmentView>();

                default:
                    return null;
            }
        }
    }
}
