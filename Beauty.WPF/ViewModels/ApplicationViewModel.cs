using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.WPF.Enums;
using Catel.MVVM;
using System.Configuration;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private readonly IEndpointCheckerService endpointCheckerService;

        public override string Title => "Система управления салоном красоты «Бьюти»";

        public ApplicationViews CurrentView { get; private set; }

        public bool IsDimmable { get; set; }
        public bool HasServerConnection { get; set; }

        public ApplicationViewModel()
        {
            endpointCheckerService = new DatabaseEndpointCheckerService
            (
                endpoint: ConfigurationManager.ConnectionStrings["BeautyDatabase"].ConnectionString,
                delay: 10000,
                OnServerConnectionStateChanged
            );

            GoToView(ApplicationViews.LoginView);
        }

        protected override async Task InitializeAsync()
        {
            endpointCheckerService.Start();

            await base.InitializeAsync();
        }

        private void OnServerConnectionStateChanged(bool result)
        {
            HasServerConnection = result;
        }

        public void GoToView(ApplicationViews view)
        {
            CurrentView = view;
        }
    }
}