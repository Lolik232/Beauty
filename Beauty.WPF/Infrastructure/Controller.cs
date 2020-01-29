using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
