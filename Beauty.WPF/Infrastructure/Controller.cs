using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.WPF.ViewModels;
using Catel.Services;

namespace Beauty.WPF.Infrastructure
{
    public static class Controller
    {
        public static ApplicationViewModel Application
        {
            get
            {
                return Container.Get<ApplicationViewModel>();
            }
        }

        public static IUnitOfWork UnitOfWork
        {
            get
            {
                return Container.Get<IUnitOfWork>();
            }
        }

        public static LoginDetails LoginDetails { get; set; }

        public static IMessageService MessageService
        {
            get
            {
                return Container.Get<IMessageService>();
            }
        }

        public static ILoginService LoginService
        {
            get
            {
                return Container.Get<ILoginService>();
            }
        }
    }
}
