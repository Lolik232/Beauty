using Beauty.Core.DTOs;
using Beauty.Core.Extensions;
using Beauty.Core.Interfaces;
using Beauty.Data.Models;
using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.Interfaces;
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

        private readonly ILoginService loginService;
        private readonly IWorkerService workerService;
        private readonly IMessageService messageService;

        public ICollection<WorkerDTO> Workers { get; set; }
        public WorkerDTO SelectedWorker { get; set; }

        public TaskCommand<object> LoginCommand { get; }

        static LoginViewModel()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public LoginViewModel(ILoginService loginService, IWorkerService workerService, IMessageService messageService)
        {
            #if DEBUG
            {
                log.Info("Подключение логов Catel'a");
                LogManager.AddDebugListener();
                log.Info("Логи Catel'a успешно подключены");
            }
            #endif

            log.Info("Инъекция зависимостей");
            this.loginService = loginService;
            this.workerService = workerService;
            this.messageService = messageService;
            log.Info("Инъекция зависимостей успешно завершена");

            log.Info("Инициализация команд");
            LoginCommand = new TaskCommand<object>(OnLoginExecuteAsync);
            log.Info("Команды успешно инициализированы");
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(async () =>
            {
                var workers = await workerService.GetAdministratorsAsync();
                Workers = new ObservableCollection<WorkerDTO>(workers);

                SelectedWorker = Workers.First();
            });

            await base.InitializeAsync();
        }

        public async Task OnLoginExecuteAsync(object parameter)
        {
            if (parameter is null)
            {
                return;
            }

            var securable = parameter as ISecurable;
            var password = securable.SecurePassword.Unsecure();

            if (await loginService.LoginAsync(SelectedWorker.Id, password))
            {
                Controller.Application.GoToView(ApplicationViews.EnrollmentView);
            }
            else
            {
                await messageService.ShowErrorAsync("Вы ввели неверный пароль. Пожалуйста, повторите попытку ввода");
            }
        }
    }
}