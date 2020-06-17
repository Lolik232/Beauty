using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
using Beauty.WPF.Enums;
using Catel;
using Catel.Logging;
using Catel.MVVM;
using Catel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private static readonly ILog log;

        public override string Title => "Вход в систему";

        private readonly ApplicationViewModel application;
        private readonly ILoginService loginService;
        private readonly IWorkerService workerService;
        private readonly IMessageService messageService;

        public bool IsWorkersLoaded { get; set; }
        public ICollection<WorkerDTO> Workers { get; set; }
        public WorkerDTO SelectedWorker { get; set; }

        public string Password { get; set; }

        public TaskCommand LoginCommand { get; }

        static LoginViewModel()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public LoginViewModel(ApplicationViewModel application, ILoginService loginService, IWorkerService workerService, IMessageService messageService)
        {
            Argument.IsNotNull(() => application);
            Argument.IsNotNull(() => loginService);
            Argument.IsNotNull(() => workerService);
            Argument.IsNotNull(() => messageService);

            this.application = application;
            this.loginService = loginService;
            this.workerService = workerService;
            this.messageService = messageService;

            LoginCommand = new TaskCommand(OnLoginCommandExecuteAsync, OnLoginCommandCanExecute);
        }

        private async Task LoadAsync()
        {
            IsWorkersLoaded = false;

            var workers = await workerService.GetAdministratorsAsync();
            Workers = new ObservableCollection<WorkerDTO>(workers);

            IsWorkersLoaded = true;
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(LoadAsync);
            await base.InitializeAsync();
        }

        private async Task OnLoginCommandExecuteAsync()
        {
            var isLoginSuccessful = await loginService.LoginAsync(SelectedWorker.Id, Password);

            if (isLoginSuccessful)
            {
                application.GoToView(ApplicationViews.EnrollmentView);
            }
            else
            {
                var errorMessage = "Вы ввели неверный пароль. Пожалуйста, повторите попытку ввода";
                await messageService.ShowErrorAsync(errorMessage);
            }
        }

        private bool OnLoginCommandCanExecute()
        {
            return SelectedWorker != null && !string.IsNullOrWhiteSpace(Password);
        }
    }
}