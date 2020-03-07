using Beauty.Core.Extensions;
using Beauty.Core.Infrastructure;
using Beauty.Data.Models;
using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.Interfaces;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    { 
        public ICollection<Worker> Workers { get; set; }
        public Worker SelectedWorker { get; set; }

        public TaskCommand<object> LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new TaskCommand<object>(OnLoginExecuteAsync);
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(async () =>
            {
                var workers = await Controller.WorkerService.GetAdministratorsAsync();
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

            var view = parameter as ISecurable;
            var password = view.SecurePassword.Unsecure();

            if (await Controller.LoginService.LoginAsync(SelectedWorker.Id, password))
            {
                Controller.Application.GoToView(ApplicationViews.EnrollmentsView);
            }
            else
            {
                await Controller.MessageService.ShowErrorAsync("Вы ввели неверный пароль. Пожалуйста, повторите попытку ввода");
            }
        }
    }
}