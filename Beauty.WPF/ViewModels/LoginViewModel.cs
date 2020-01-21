using Beauty.WPF.Commands;
using Beauty.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Beauty.WPF.Infrastructure;

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(LoginAction);
        }

        public void LoginAction()
        {
            ApplicationController.ApplicationViewModel.GoToView(ApplicationViews.MainView);
        }
    }
}
