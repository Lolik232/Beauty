using Beauty.Core.Infrastructure;
using Beauty.WPF.Enums;
using Catel.MVVM;

namespace Beauty.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public static Session Session => Session.GetSession();

        public override string Title => "Система управления салоном красоты «Бьюти»";

        public ApplicationViews CurrentView { get; private set; }

        public ApplicationViewModel()
        {
            GoToView(ApplicationViews.LoginView);
        }

        public void GoToView(ApplicationViews view)
        {
            CurrentView = view;
        }
    }
}