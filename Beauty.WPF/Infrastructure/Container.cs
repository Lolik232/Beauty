using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.WPF.Interfaces;
using Beauty.WPF.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.Infrastructure
{
    public static class Container
    {
        public static IKernel Kernel { get; private set; } 

        static Container()
        {
            Kernel = new StandardKernel();
        }

        public static void Setup()
        {
            var applicationViewModel = new ApplicationViewModel();
            Kernel.Bind<ApplicationViewModel>().ToConstant(applicationViewModel);

            var messageService = new MessageService();
            Kernel.Bind<IMessageService>().ToConstant(messageService);
        }

        public static TImplementation Get<TImplementation>()
        {
            return Kernel.Get<TImplementation>();
        }
    }
}
