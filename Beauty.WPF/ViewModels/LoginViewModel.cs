using Beauty.Core.Extensions;
using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using Beauty.Data.UnitOfWorks;
using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.Interfaces;
using Beauty.WPF.Views;
using Catel.MVVM;
using Catel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            LoginCommand = new TaskCommand<object>
            (
                LoginAsync,
                (parameter) =>
                {
                    var collectionSettings = parameter as ICollectionable;
                    var securitySettings = parameter as ISecurable;

                    if (collectionSettings is null && securitySettings is null)
                    {
                        return false;
                    }

                    return collectionSettings.HasItems && !securitySettings.IsPasswordEmpty;
                }
            );

            Task.Factory.StartNew(LoadPropertiesAsync);
        }

        protected async Task LoadPropertiesAsync()
        {
            var workers = await Controller.UnitOfWork.Workers.FindAdministratorsAsync();
            Workers = new ObservableCollection<Worker>(workers);
        }

        public async Task LoginAsync(object parameter)
        {
            if (parameter is null)
            {
                return;
            }

            var securitySettings = parameter as ISecurable;

            var password = securitySettings.SecurePassword.Unsecure();
            var loginResult = await Controller.LoginService.LoginAsync(SelectedWorker, password);

            if (!loginResult.IsFailed)
            {
                Controller.LoginDetails = loginResult as LoginDetails;
                Controller.Application.GoToView(ApplicationViews.EnrollmentView);
            }
            else
            {
                await Controller.MessageService.ShowErrorAsync("Вы ввели неверный пароль. Пожалуйста, повторите попытку ввода");
            }
        }
    }
}