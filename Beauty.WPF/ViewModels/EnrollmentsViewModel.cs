using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
using Catel;
using Catel.Logging;
using Catel.MVVM;
using Catel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Beauty.Core.Extensions;

namespace Beauty.WPF.ViewModels
{
    public class EnrollmentsViewModel : ViewModelBase
    {
        private static readonly ILog log;

        public override string Title => "Список заявок";

        private readonly IEnrollmentService enrollmentService;
        private readonly IUIVisualizerService uiVisualizerService;
        private readonly IMessageService messageService;

        public bool IsEnrollmentsLoaded { get; set; }
        public string FilterText { get; set; }
        public bool NeedFindRelevantEnrollments { get; set; }
        public ICollection<EnrollmentDTO> Enrollments { get; set; }
        public EnrollmentDTO SelectedEnrollment { get; set; }

        public TaskCommand<string> FilterTextChangedCommand { get; set; }
        public TaskCommand<bool> NeedFindRelevantEnrollmentsCommand { get; set; }
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

            FilterTextChangedCommand = new TaskCommand<string>(OnFilterTextChangedCommandExecuteAsync);
            NeedFindRelevantEnrollmentsCommand = new TaskCommand<bool>(OnNeedFindRelevantEnrollmentsCommandExecuteAsync);
            CreateEnrollmentCommand = new TaskCommand(OnCreateEnrollmentCommandExecuteAsync);
            EditEnrollmentCommand = new TaskCommand(OnEditEnrollmentCommandExecuteAsync);
            RemoveEnrollmentCommand = new TaskCommand(OnRemoveEnrollmentCommandExecuteAsync, OnRemoveEnrollmentCommandCanExecute);
        }

        private async Task UpdateEnrollmentsAsync()
        {
            IsEnrollmentsLoaded = false;

            var enrollments = default(IEnumerable<EnrollmentDTO>);

            if (NeedFindRelevantEnrollments)
            {
                enrollments = await enrollmentService.GetRelevantEnrollmentsAsync(FilterText);
            }
            else
            {
                enrollments = await enrollmentService.GetEnrollmentsAsync(FilterText);
            }

            Enrollments = new ObservableCollection<EnrollmentDTO>(enrollments);

            IsEnrollmentsLoaded = true;
        }

        protected override async Task InitializeAsync()
        {
            await UpdateEnrollmentsAsync();
            await base.InitializeAsync();
        }

        private async Task OnFilterTextChangedCommandExecuteAsync(string filterText)
        {
            FilterText = filterText;
            await UpdateEnrollmentsAsync();
        }

        private async Task OnNeedFindRelevantEnrollmentsCommandExecuteAsync(bool needFindRelevantEnrollments)
        {
            NeedFindRelevantEnrollments = needFindRelevantEnrollments;
            await UpdateEnrollmentsAsync();
        }

        private async Task OnCreateEnrollmentCommandExecuteAsync()
        {
            var isCancel = await uiVisualizerService.ShowDialogAsync<EnrollmentDetailsViewModel>() ?? false;

            if (isCancel)
            {
                await UpdateEnrollmentsAsync();
                SelectedEnrollment = Enrollments.LastOrDefault();
            }
        }

        private async Task OnEditEnrollmentCommandExecuteAsync()
        {
            var selectedEnrollmentId = SelectedEnrollment.Id;

            var enrollment = await enrollmentService.GetEnrollmentAsync(selectedEnrollmentId);
            await uiVisualizerService.ShowDialogAsync<EnrollmentDetailsViewModel>(enrollment);
            await UpdateEnrollmentsAsync();

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
                await UpdateEnrollmentsAsync();
            }
        }

        private bool OnRemoveEnrollmentCommandCanExecute()
        {
            return SelectedEnrollment != null;
        }
    }
}
