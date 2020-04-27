using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
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
    public class EnrollmentsViewModel : ViewModelBase
    {
        private static readonly ILog log;

        public override string Title => "Список заявок";

        private readonly IEnrollmentService enrollmentService;
        private readonly IUIVisualizerService uiVisualizerService;
        private readonly IMessageService messageService;

        public Task<IEnumerable<EnrollmentDTO>> EnrollmentsLoadingTask { get; set; }
        public ICollection<EnrollmentDTO> Enrollments { get; set; }
        public EnrollmentDTO SelectedEnrollment { get; set; }

        public TaskCommand CreateEnrollmentCommand { get; set; }
        public TaskCommand EditEnrollmentCommand { get; set; }
        public TaskCommand RemoveEnrollmentCommand { get; set; }

        static EnrollmentsViewModel()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public EnrollmentsViewModel(IEnrollmentService enrollmentService, IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            Argument.IsNotNull(() => enrollmentService);
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => messageService);

            this.enrollmentService = enrollmentService;
            this.uiVisualizerService = uiVisualizerService;
            this.messageService = messageService;

            CreateEnrollmentCommand = new TaskCommand(OnCreateEnrollmentCommandExecuteAsync);
            EditEnrollmentCommand = new TaskCommand(OnEditEnrollmentCommandExecuteAsync);
            RemoveEnrollmentCommand = new TaskCommand(OnRemoveEnrollmentCommandExecuteAsync, OnRemoveEnrollmentCommandCanExecute);
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(() =>
            {
                EnrollmentsLoadingTask = enrollmentService.GetRelevantEnrollmentsAsync();
                EnrollmentsLoadingTask.Wait();

                Enrollments = new ObservableCollection<EnrollmentDTO>(EnrollmentsLoadingTask.Result);
            });

            await base.InitializeAsync();
        }

        private async Task OnCreateEnrollmentCommandExecuteAsync()
        {
            var isCancel = await uiVisualizerService.ShowDialogAsync<EnrollmentDetailsViewModel>() ?? false;

            if (isCancel)
            {
                await InitializeAsync();
                SelectedEnrollment = Enrollments.LastOrDefault();
            }
        }

        private async Task OnEditEnrollmentCommandExecuteAsync()
        {
            var selectedEnrollmentId = SelectedEnrollment.Id;

            var enrollment = await enrollmentService.GetEnrollmentAsync(selectedEnrollmentId);
            await uiVisualizerService.ShowDialogAsync<EnrollmentDetailsViewModel>(enrollment);
            await InitializeAsync();

            SelectedEnrollment = Enrollments.FirstOrDefault(Enrollment => Enrollment.Id.Equals(selectedEnrollmentId));
        }

        private async Task OnRemoveEnrollmentCommandExecuteAsync()
        {
            var caption = "Удаление заявки";
            var message = $"Вы действительно хотите удалить заявку №{SelectedEnrollment.Id}?";
            var dialogResult = await messageService.ShowAsync(message, caption, MessageButton.OKCancel, MessageImage.Question);

            if (dialogResult.Equals(MessageResult.OK))
            {
                await enrollmentService.RemoveEnrollmentAsync(SelectedEnrollment.Id);
                await InitializeAsync();
            }
        }

        private bool OnRemoveEnrollmentCommandCanExecute()
        {
            return SelectedEnrollment != null;
        }
    }
}
