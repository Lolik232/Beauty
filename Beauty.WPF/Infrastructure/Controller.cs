using Beauty.WPF.ViewModels;
using Catel.MVVM.Views;
using Catel.Services;

namespace Beauty.WPF.Infrastructure
{
    public static class Controller
    {
        public static ApplicationViewModel Application => Container.Get<ApplicationViewModel>();
      
        public static IMessageService MessageService => Container.Get<IMessageService>();

        public static IView GetView<TImplementation>()
        {
            return Container.Get<TImplementation>() as IView;
        }
    }
}