using Beauty.WPF.Commands;
using Beauty.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Beauty.WPF.Infrastructure;
using System.Collections.ObjectModel;

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ObservableCollection<WorkerViewModel> workersViewModels;
        private WorkerViewModel selectedWorkerViewModel;
        private string password;

        public ObservableCollection<WorkerViewModel> WorkersViewModels
        {
            get
            {
                return workersViewModels;
            }

            set
            {
                workersViewModels = value;
                OnPropertyChanged(nameof(WorkersViewModels));
            }
        }

        public WorkerViewModel SelectedWorkerViewModel
        {
            get
            {
                return selectedWorkerViewModel;
            }

            set
            {
                selectedWorkerViewModel = value;
                OnPropertyChanged(nameof(SelectedWorkerViewModel));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public Predicate<object> LoginCondition { get; }

        public LoginViewModel()
        {
            LoginCondition = (NullableParameter) => SelectedWorkerViewModel != null && !string.IsNullOrEmpty(Password); 
            LoginCommand = new RelayCommand(LoginAction, LoginCondition);
        }

        public void LoginAction()
        {
            /* Авторизация */

            ApplicationController.ApplicationViewModel.GoToView(ApplicationViews.MainView);
        }
    }
}
