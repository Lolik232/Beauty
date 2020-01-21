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
    public static class NinjectContainer
    {
        public static IKernel Kernel { get; private set; } 

        static NinjectContainer()
        {
            Kernel = new StandardKernel();
        }

        public static void Setup()
        {
            var applicationViewModel = new ApplicationViewModel();
            Kernel.Bind<ApplicationViewModel>().ToConstant(applicationViewModel);
        }

        public static TImplementation Get<TImplementation>()
        {
            return Kernel.Get<TImplementation>();
        }
    }
}
