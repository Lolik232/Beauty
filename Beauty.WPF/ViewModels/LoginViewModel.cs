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
using Beauty.Data.Models;
using Beauty.Data.Interfaces;
using Beauty.Data.UnitOfWorks;
using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.Core.Infrastructure;
using Beauty.WPF.Interfaces;
using Beauty.Core.Extensions;

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessageService messageService;
        private readonly ILoginService loginService;

        private ICollection<Worker> workers;
        private Worker selectedWorker;
        private string errorMessage;

        public bool IsDataLoading
        {
            get
            {
                return Workers is null || Workers.Count.Equals(0);
            }
        }

        public ICollection<Worker> Workers
        {
            get
            {
                return workers;
            }

            set
            {
                workers = value;
                OnPropertyChanged(nameof(Workers));
                OnPropertyChanged(nameof(IsDataLoading));
            }
        }

        public Worker SelectedWorker
        {
            get
            {
                return selectedWorker;
            }

            set
            {
                selectedWorker = value;
                OnPropertyChanged(nameof(SelectedWorker));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }

            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        public bool HasErrors
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ErrorMessage);
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            unitOfWork = new UnitOfWork();
            messageService = new MessageService();
            loginService = new LoginService(unitOfWork);

            LoginCommand = new ParameterizedCommand
            (
                LoginAsync,
                (parameter) =>
                {
                    var password = (parameter as ILoginView)?.SecurePassword;
                    return SelectedWorker != null && !password.Length.Equals(0);
                }
            );

            Task.Factory.StartNew(LoadPropertiesAsync);
        }

        public async void LoadPropertiesAsync()
        {
            var workers = await unitOfWork.Workers.FindAdministratorsAsync();
            Workers = new ObservableCollection<Worker>(workers);
        }

        public async void LoginAsync(object parameter)
        {
            var securePassword = (parameter as ILoginView)?.SecurePassword;
            var password = securePassword.Unsecure();

            var loginResult = await loginService.LoginAsync(SelectedWorker, password);

            if (!loginResult.IsFailed)
            {
                ApplicationController.LoginDetails = loginResult as LoginDetails;
                ApplicationController.ApplicationViewModel.GoToView(ApplicationViews.MainView);
            }
            else
            {
                ErrorMessage = "Вы ввели неверный пароль. Пожалуйста, повторите попытку ввода снова";
            }
        }
    }
}