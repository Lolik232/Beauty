using Beauty.WPF.Infrastructure;
using Beauty.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.Infrastructure
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; }

        static ViewModelLocator()
        {
            Instance = new ViewModelLocator();
        }

        public static ApplicationViewModel ApplicationViewModel
        {
            get
            {
                return Controller.Application;
            }
        }
    }
}
