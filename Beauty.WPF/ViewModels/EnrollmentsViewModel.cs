using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class EnrollmentsViewModel : ViewModelBase
    {
        public Command LogoutCommand { get; set; }

        public EnrollmentsViewModel()
        {
            LogoutCommand = new Command(OnLogoutExecute);
        }

        public void OnLogoutExecute() 
        {
            Controller.Application.GoToView(ApplicationViews.LoginView);
        }
    }
}
