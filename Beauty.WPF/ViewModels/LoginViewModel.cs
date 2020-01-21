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

namespace Beauty.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;

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

            LoginCommand = new ParameterizedCommand(LoginCommandExecuteAsync, (parameter) => SelectedWorker != null && !string.IsNullOrEmpty(parameter as string));

            Task.Factory.StartNew(SetupPropertiesAsync);
        }

        public async void SetupPropertiesAsync()
        {
            var workers = await unitOfWork.Workers.FindAdministratorsAsync();
            Workers = new ObservableCollection<Worker>(workers);
        }

        public async void LoginCommandExecuteAsync(object parameter)
        {
            /* Авторизация */

            ApplicationController.ApplicationViewModel.GoToView(ApplicationViews.MainView);
        }
    }
}
