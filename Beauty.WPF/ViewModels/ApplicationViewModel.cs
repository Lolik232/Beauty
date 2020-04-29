using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.WPF.Enums;
using Catel;
using Catel.Logging;
using Catel.MVVM;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private readonly ILoginService loginService;
        private readonly IEndpointCheckerService endpointCheckerService;

        public override string Title => "Система управления салоном красоты «Бьюти»";

        public ApplicationViews CurrentView { get; private set; }

        public bool IsDimmable { get; set; }
        public bool HasServerConnection { get; set; }
        public bool IsMenuShown { get; set; }

        public Command OpenEnrollmentsViewCommand { get; set; }
        public Command OpenSettingsViewCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public ApplicationViewModel(ILoginService loginService)
        {
            Argument.IsNotNull(() => loginService);

            this.loginService = loginService;

            OpenEnrollmentsViewCommand = new Command(OnOpenEnrollmentsViewCommandExecute, OnOpenEnrollmentsViewCommandCanExecute);
            OpenSettingsViewCommand = new Command(OnOpenSettingsViewCommandExecute, OnOpenSettingsViewCommandCanExecute);
            LogoutCommand = new Command(OnLogoutCommandExecute);

            endpointCheckerService = new DatabaseEndpointCheckerService
            (
                endpoint: ConfigurationManager.ConnectionStrings["BeautyDatabase"].ConnectionString,
                delay: 10000,
                OnServerConnectionStateChanged
            );
        }

        protected override async Task InitializeAsync()
        {
            endpointCheckerService.Start();

            GoToView(ApplicationViews.LoginView);

            await base.InitializeAsync();
        }

        private void OnOpenEnrollmentsViewCommandExecute()
        {
            GoToView(ApplicationViews.EnrollmentView);
        }

        private bool OnOpenEnrollmentsViewCommandCanExecute()
        {
            return !CurrentView.Equals(ApplicationViews.EnrollmentView);
        }

        private void OnOpenSettingsViewCommandExecute()
        {
            GoToView(ApplicationViews.SettingsView);
        }

        private bool OnOpenSettingsViewCommandCanExecute()
        {
            return !CurrentView.Equals(ApplicationViews.SettingsView);
        }

        private void OnLogoutCommandExecute()
        {
            loginService.Logout();
            GoToView(ApplicationViews.LoginView);
        }

        private void OnServerConnectionStateChanged(bool result)
        {
            HasServerConnection = result;
        }

        public void GoToView(ApplicationViews view)
        {
            CurrentView = view;
            IsMenuShown = !CurrentView.Equals(ApplicationViews.LoginView);
        }
    }
}