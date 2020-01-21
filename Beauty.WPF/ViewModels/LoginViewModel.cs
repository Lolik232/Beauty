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

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessageService messageService;
        private readonly ILoginService loginService;

        private ICollection<Worker> workers;
        private Worker selectedWorker;

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

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            unitOfWork = new UnitOfWork();
            messageService = new MessageService();
            loginService = new LoginService(unitOfWork);

            LoginCommand = new ParameterizedCommand(LoginCommandExecuteAsync,
                (parameter) =>
                {
                    var password = parameter as string;
                    return SelectedWorker != null && !string.IsNullOrEmpty(password);
                });

            Task.Factory.StartNew(SetupPropertiesAsync);
        }

        public async void SetupPropertiesAsync()
        {
            var workers = await unitOfWork.Workers.FindAdministratorsAsync();
            Workers = new ObservableCollection<Worker>(workers);
        }

        public async void LoginCommandExecuteAsync(object parameter)
        {
            var password = parameter as string;
            var result = await loginService.LoginAsync(SelectedWorker, password);

            if (!result.IsFailed)
            {
                ApplicationController.LoginDetails = result as LoginDetails;
                ApplicationController.ApplicationViewModel.GoToView(ApplicationViews.MainView);
            }
            else
            {
                var message = "Вы ввели неверный пароль\n" +
                    "Повторите попытку снова или сообщите об этой ошибке администратору";

                messageService.ShowError(message);
            }
        }
    }
}
