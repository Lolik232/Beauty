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

        public string FilterText { get; set; }
        public ICollection<DateTime> Dates { get; set; }
        public DateTime SelectedDate { get; set; }
        public ICollection<EnrollmentDTO> Enrollments { get; set; }
        public EnrollmentDTO SelectedEnrollment { get; set; }

        public TaskCommand<string> FilterTextChangedCommand { get; set; }
        public TaskCommand DateSelectCommand { get; set; }
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
            DateSelectCommand = new TaskCommand(UpdateEnrollmentsAsync, OnDateSelectCommandCanExecute);
            CreateEnrollmentCommand = new TaskCommand(OnCreateEnrollmentCommandExecuteAsync);
            EditEnrollmentCommand = new TaskCommand(OnEditEnrollmentCommandExecuteAsync);
            RemoveEnrollmentCommand = new TaskCommand(OnRemoveEnrollmentCommandExecuteAsync, OnRemoveEnrollmentCommandCanExecute);
        }

        private async Task UpdateDatesAsync()
        {
            var dates = await enrollmentService.GetEnrollmentDatesAsync();
            Dates = new ObservableCollection<DateTime>(dates);

            var comparer = new DateTime();
            var isDateExists = !Dates.FirstOrDefault(Date => Date.Equals(SelectedDate)).Equals(comparer);

            if (!isDateExists)
            {
                var date = Dates.FirstOrDefault(Date => Date.Equals(DateTime.Now.Date));

                if (date.Equals(comparer))
                {
                    date = Dates.FirstOrDefault();
                }

                SelectedDate = date;
            }
        }

        private async Task UpdateEnrollmentsAsync()
        {
            var enrollments = await enrollmentService.GetEnrollmentsAsync(FilterText, SelectedDate);
            Enrollments = new ObservableCollection<EnrollmentDTO>(enrollments);
        }

        protected override async Task InitializeAsync()
        {
            await UpdateDatesAsync();
            await base.InitializeAsync();
        }

        private async Task OnFilterTextChangedCommandExecuteAsync(string filterText)
        {
            FilterText = filterText;
            await UpdateEnrollmentsAsync();
        }

        private bool OnDateSelectCommandCanExecute()
        {
            return Dates != null && !Dates.Count().Equals(0);
        }

        private async Task OnCreateEnrollmentCommandExecuteAsync()
        {
            var isCancel = await uiVisualizerService.ShowDialogAsync<EnrollmentDetailsViewModel>() ?? false;

            if (isCancel)
            {
                await UpdateDatesAsync();
                await UpdateEnrollmentsAsync();
                SelectedEnrollment = Enrollments.LastOrDefault();
            }
        }

        private async Task OnEditEnrollmentCommandExecuteAsync()
        {
            var selectedEnrollmentId = SelectedEnrollment.Id;

            var enrollment = await enrollmentService.GetEnrollmentAsync(selectedEnrollmentId);
            await uiVisualizerService.ShowDialogAsync<EnrollmentDetailsViewModel>(enrollment);
            await UpdateDatesAsync();
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
                await UpdateDatesAsync();
                await UpdateEnrollmentsAsync();
            }
        }

        private bool OnRemoveEnrollmentCommandCanExecute()
        {
            return SelectedEnrollment != null;
        }
    }
}
