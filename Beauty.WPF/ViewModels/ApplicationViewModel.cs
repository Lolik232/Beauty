using Beauty.Core.Infrastructure;
using Beauty.WPF.Enums;
using Beauty.WPF.Extensions;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.Interfaces;
using Beauty.WPF.Views;
using Catel.IoC;
using Catel.MVVM;
using Catel.MVVM.Views;
using Catel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public override string Title
        {
            get
            {
                return "Система управления салоном красоты «Бьюти»";
            }
        }

        public ApplicationViews CurrentView { get; set; } = ApplicationViews.None;

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