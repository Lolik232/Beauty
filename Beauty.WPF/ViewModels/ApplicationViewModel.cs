using Beauty.Core.Infrastructure;
using Beauty.WPF.Enums;
using Catel.MVVM;

namespace Beauty.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public override string Title => "Система управления салоном красоты «Бьюти»";

        public static Session Session => Session.GetSession();

        public ApplicationViews CurrentView { get; private set; }

        public object[] CurrentViewParameters { get; private set; }

        public ApplicationViewModel()
        {
            GoToView(ApplicationViews.LoginView);
        }

        public void GoToView(ApplicationViews view, object[] parameters = null)
        {
            CurrentViewParameters = parameters;
            CurrentView = view;
        }
    }
}