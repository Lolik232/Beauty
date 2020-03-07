using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Beauty.Data.Models;
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

        public static IWorkerService WorkerService
        {
            get
            {
                return Container.Get<IWorkerService>();
            }
        }

        public static Session Session
        {
            get
            {
                return Session.GetSession();
            }
        }
    }
}
