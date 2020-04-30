using Beauty.Core.Extensions;
using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Catel;
using Catel.Logging;
using Catel.MVVM;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public override string Title => "Профиль";

        private readonly IWorkerService workerService;

        public bool IsProfileLoaded { get; set; }
        public string WorkerShortname { get; set; }
        public string WorkerPositions { get; set; }
        public string WorkerPhoneNumber { get; set; }

        public ProfileViewModel(IWorkerService workerService)
        {
            Argument.IsNotNull(() => workerService);

            this.workerService = workerService;
        }

        protected override async Task InitializeAsync()
        {
            IsProfileLoaded = false;

            var session = Session.GetSession();

            if (session.Worker is null)
            {
                return;
            }

            WorkerShortname = await workerService.GetWorkerShortnameAsync(session.Worker.Id);

            var workerPositions = await workerService.GetWorkerPositionsAsync(session.Worker.Id);
            WorkerPositions = workerPositions.ToLine();

            WorkerPhoneNumber = session.Worker.PhoneNumber;

            IsProfileLoaded = true;

            await base.InitializeAsync();
        }

        protected override Task CloseAsync()
        {
            return Task.CompletedTask;
        }
    }
}
