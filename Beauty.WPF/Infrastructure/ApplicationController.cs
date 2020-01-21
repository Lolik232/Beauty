using Beauty.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.Infrastructure
{
    public static class ApplicationController
    {
        public static ApplicationViewModel ApplicationViewModel
        {
            get
            {
                return NinjectContainer.Get<ApplicationViewModel>();
            }
        }
    }
}
