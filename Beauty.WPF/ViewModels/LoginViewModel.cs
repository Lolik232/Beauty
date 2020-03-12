using Beauty.Core.Extensions;
using Beauty.Core.Interfaces;
using Beauty.Data.Models;
using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.Interfaces;
using Catel.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginService loginService;
        private readonly IWorkerService workerService;

        public ICollection<Worker> Workers { get; set; }
        public Worker SelectedWorker { get; set; }

        public TaskCommand<object> LoginCommand { get; }

        public LoginViewModel(ILoginService loginService, IWorkerService workerService)
        {
            this.loginService = loginService;
            this.workerService = workerService;

            LoginCommand = new TaskCommand<object>(OnLoginExecuteAsync);
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(async () =>
            {
                var workers = await workerService.GetAdministratorsAsync();
                Workers = new ObservableCollection<Worker>(workers);

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

            var isAuthorized = await loginService.LoginAsync(SelectedWorker.Id, password);

            if (isAuthorized)
            {
                Controller.Application.GoToView(ApplicationViews.EnrollmentView);
            }
            else
            {
                await Controller.MessageService.ShowErrorAsync("Вы ввели неверный пароль. Пожалуйста, повторите попытку ввода");
            }
        }
    }
}