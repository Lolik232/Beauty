using Beauty.Core.Infrastructure;
using Beauty.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        private ApplicationViews currentView;

        public ApplicationViews CurrentView
        { 
            get
            {
                return currentView;
            }

            private set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public LoginDetails LoginDetails { get; set; }

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