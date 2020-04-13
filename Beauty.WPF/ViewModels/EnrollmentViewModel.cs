using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Catel.IoC;
using Catel.Logging;
using Catel.MVVM;
using Catel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class EnrollmentViewModel : ViewModelBase
    {
        private static readonly ILog log;

        public override string Title => "Заявки";

        private readonly IEnrollmentService enrollmentService;
        private readonly IUIVisualizerService uiVisualizerService;
        private readonly IMessageService messageService;

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
        public EnrollmentDTO SelectedEnrollment { get; set; }

        public Command CreateEnrollmentCommand { get; set; } 
        public TaskCommand EditEnrollmentCommand { get; set; }

        static EnrollmentViewModel()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public EnrollmentViewModel(IEnrollmentService enrollmentService, IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            this.enrollmentService = enrollmentService;
            this.uiVisualizerService = uiVisualizerService;
            this.messageService = messageService;

            CreateEnrollmentCommand = new Command(OnCreateEnrollmentExecute);
            EditEnrollmentCommand = new TaskCommand(OnEditEnrollmentExecuteAsync);
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(async () =>
            {
                var enrollments = await enrollmentService.GetRelevantEnrollmentsAsync();
                Enrollments = new ObservableCollection<EnrollmentDTO>(enrollments);
            });

            await base.InitializeAsync();
        }

        public void OnCreateEnrollmentExecute()
        {
            Controller.Application.GoToView(ApplicationViews.EnrollmentDetailsView);
        }

        public async Task OnEditEnrollmentExecuteAsync()
        {
            //var parameters = new object[]
            //{
            //    SelectedEnrollment
            //};

            var typeFactory = this.GetTypeFactory();
            var enrollmentDetailsViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<EnrollmentDetailsViewModel>(SelectedEnrollment);

            await uiVisualizerService.ShowDialogAsync(enrollmentDetailsViewModel);

            //Controller.Application.GoToView(ApplicationViews.EnrollmentDetailsView, parameters);
        }
    }
}
