using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
using Beauty.Data.Models;
using Catel;
using Catel.Collections;
using Catel.Logging;
using Catel.MVVM;
using Catel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class EnrollmentDetailsViewModel : ViewModelBase, IDataErrorInfo
    {
        private static readonly ILog log;

        private readonly IEnrollmentService enrollmentService;
        private readonly IServiceManager serviceManager;
        private readonly IWorkerService workerService;
        private readonly IDateService dateTimeService;
        private readonly IMessageService messageService;

        public bool IsServicesLoaded { get; set; }
        public Enrollment Enrollment { get; set; }
        public string ClientFirstname { get; set; }
        public string ClientPhoneNumber { get; set; }
        public bool IsClientPhoneNumberFilled { get; set; }
        public ICollection<int> Days { get; set; }
        public int SelectedDay { get; set; }
        public ICollection<string> Months { get; set; }
        public string SelectedMonth { get; set; }
        public ICollection<int> Years { get; set; }
        public int SelectedYear { get; set; }
        public string Time { get; set; }
        public bool IsTimeFilled { get; set; }
        public bool IsTimeFilledCorrectly { get; set; }
        public string Description { get; set; }
        public ICollection<Service> Services { get; set; }
        public Service SelectedService { get; set; }
        public ICollection<WorkerDTO> Workers { get; set; }
        public WorkerDTO SelectedWorker { get; set; }
        public ICollection<ServiceDTO> EnrollmentServices { get; set; }

        public Command MonthSelectCommand { get; set; }
        public TaskCommand ServiceSelectCommand { get; set; }
        public Command AddEnrollmentServiceCommand { get; set; }
        public TaskCommand<ServiceDTO> RemoveEnrollmentServiceCommand { get; set; }
        public TaskCommand RemoveCommand { get; set; }
        public TaskCommand SaveCommand { get; set; }
        public TaskCommand CloseCommand { get; set; }

        public string this[string columnName]
        {
            get
            {
                var error = string.Empty;

                if (columnName.Equals(nameof(Time)))
                {
                    var timeArray = Time?.Split(':');

                    if (timeArray is null)
                    {
                        error = "Время не указано";

                        return error;
                    }

                    if (!int.TryParse(timeArray[0], out int hours) || !int.TryParse(timeArray[1], out int minutes) || hours < 0 || hours >= 24 || minutes < 0 || minutes >= 60)
                    {
                        error = "Введено некорректное время";
                    }
                }

                IsTimeFilledCorrectly = error.Equals(string.Empty);

                return error;
            }
        }

        static EnrollmentDetailsViewModel()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public EnrollmentDetailsViewModel(IEnrollmentService enrollmentService, IServiceManager serviceManager, IWorkerService workerService, IDateService dateTimeService, IMessageService messageService)
        {
            Argument.IsNotNull(() => enrollmentService);
            Argument.IsNotNull(() => serviceManager);
            Argument.IsNotNull(() => workerService);
            Argument.IsNotNull(() => dateTimeService);
            Argument.IsNotNull(() => messageService);

            this.enrollmentService = enrollmentService;
            this.serviceManager = serviceManager;
            this.workerService = workerService;
            this.dateTimeService = dateTimeService;
            this.messageService = messageService;

            Title = "Новая заявка";

            MonthSelectCommand = new Command(OnMonthSelectCommandExecute);
            ServiceSelectCommand = new TaskCommand(OnServiceSelectCommandExecuteAsync);
            AddEnrollmentServiceCommand = new Command(OnAddEnrollmentServiceCommandExecute, OnAddEnrollmentServiceCommandCanExecute);
            RemoveEnrollmentServiceCommand = new TaskCommand<ServiceDTO>(OnRemoveEnrollmentServiceCommandExecuteAsync);
            RemoveCommand = new TaskCommand(OnRemoveCommandExecuteAsync, OnRemoveCommandCanExecute);
            SaveCommand = new TaskCommand(OnSaveCommandExecuteAsync, OnSaveCommandCanExecute);
            CloseCommand = new TaskCommand(OnCloseExecuteAsync);
        }

        public EnrollmentDetailsViewModel(Enrollment enrollment, IEnrollmentService enrollmentService, IServiceManager serviceManager, IWorkerService workerService, IDateService dateTimeService, IMessageService messageService)
            : this(enrollmentService, serviceManager, workerService, dateTimeService, messageService)
        {
            Argument.IsNotNull(() => enrollment);

            Enrollment = enrollment;
            Title = $"Заявка №{Enrollment.Id}";
        }

        private async Task LoadAsync()
        {
            var months = dateTimeService.GetGenitiveMonthNames();
            Months = new ObservableCollection<string>(months);
            SelectedMonth = dateTimeService.GetGenitiveMonthName(DateTime.Now.Month - 1);

            SelectedDay = DateTime.Now.Day;

            var years = dateTimeService.GetYearsInRange(1970, DateTime.Now.Year);
            Years = new ObservableCollection<int>(years);
            SelectedYear = DateTime.Now.Year;

            Time = DateTime.Now.ToString("HH:mm");

            IsServicesLoaded = false;

            var services = await serviceManager.GetServicesAsync();
            Services = new ObservableCollection<Service>(services);

            IsServicesLoaded = true;

            EnrollmentServices = new ObservableCollection<ServiceDTO>();

            if (Enrollment != null)
            {
                var enrollmentServices = await serviceManager.GetEnrollmentServicesAsync(Enrollment.Id);

                enrollmentServices.ForEach(ServiceDTO =>
                {
                    services.ForEach(Service =>
                    {
                        if (ServiceDTO.Id.Equals(Service.Id))
                        {
                            Services.Remove(Service);
                        }
                    });
                });

                EnrollmentServices = new ObservableCollection<ServiceDTO>(enrollmentServices);

                ClientFirstname = Enrollment.ClientFirstname;
                ClientPhoneNumber = Enrollment.ClientPhoneNumber;
                SelectedDay = Enrollment.DateTime.Day;
                SelectedMonth = dateTimeService.GetGenitiveMonthName(Enrollment.DateTime.Month - 1);
                SelectedYear = Enrollment.DateTime.Year;
                Time = Enrollment.DateTime.ToString("HH:mm");
                Description = Enrollment.Description;
            }
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(LoadAsync);
            await base.InitializeAsync();
        }

        private void OnMonthSelectCommandExecute()
        {
            var days = dateTimeService.GetDaysFromMonth(SelectedYear, SelectedMonth);
            Days = new ObservableCollection<int>(days);
            var daysCountInMonth = Days.Count();

            if (daysCountInMonth < SelectedDay)
            {
                SelectedDay = daysCountInMonth;
            }
        }

        private async Task OnServiceSelectCommandExecuteAsync()
        {
            if (SelectedService is null)
            {
                return;
            }

            var workers = await workerService.GetServiceWorkersAsync(SelectedService.Id);
            Workers = new ObservableCollection<WorkerDTO>(workers);
        }

        private void OnAddEnrollmentServiceCommandExecute()
        {
            var serviceDTO = new ServiceDTO()
            {
                Id = SelectedService.Id,
                WorkerId = SelectedWorker.Id,
                Title = SelectedService.Title,
                WorkerShortname = SelectedWorker.Shortname
            };

            EnrollmentServices.Add(serviceDTO);

            var service = Services.FirstOrDefault(Service => Service.Id.Equals(SelectedService.Id));
            Services.Remove(service);

            SelectedWorker = null;
        }

        private bool OnAddEnrollmentServiceCommandCanExecute()
        {
            return SelectedService != null && SelectedWorker != null;
        }

        private async Task OnRemoveEnrollmentServiceCommandExecuteAsync(ServiceDTO serviceDTO)
        {
            var service = await serviceManager.GetServiceAsync(serviceDTO.Id);

            if (service.Id <= Services.Count)
            {
                var services = Services as IList<Service>;
                services.Insert(service.Id - 1, service);
            }
            else
            {
                Services.Add(service);
            }

            EnrollmentServices.Remove(serviceDTO);
        }

        private async Task OnRemoveCommandExecuteAsync()
        {
            var caption = "Удаление заявки";
            var message = $"Вы действительно хотите удалить эту заявку?";
            var dialogResult = await messageService.ShowAsync(message, caption, MessageButton.OKCancel, MessageImage.Question);

            if (dialogResult.Equals(MessageResult.OK))
            {
                await enrollmentService.RemoveEnrollmentAsync(Enrollment.Id);
                await this.CancelAndCloseViewModelAsync();
            }
        }

        private bool OnRemoveCommandCanExecute()
        {
            return Enrollment != null;
        }

        private async Task OnSaveCommandExecuteAsync()
        {
            await this.SaveAndCloseViewModelAsync();
        }

        private bool OnSaveCommandCanExecute()
        {
            return !string.IsNullOrWhiteSpace(ClientFirstname) && IsClientPhoneNumberFilled && SelectedDay != 0 && !string.IsNullOrWhiteSpace(SelectedMonth) && SelectedYear != 0 && IsTimeFilled && IsTimeFilledCorrectly;
        }

        protected override async Task<bool> SaveAsync()
        {
            var monthIndex = dateTimeService.GetGenitiveMonthIndex(SelectedMonth) + 1;

            var timeArray = Time.Split(':');
            var hours = int.Parse(timeArray[0]);
            var minutes = int.Parse(timeArray[1]);

            var dateTime = new DateTime(SelectedYear, monthIndex, SelectedDay, hours, minutes, 0);

            if (Enrollment is null)
            {
                Enrollment = await enrollmentService.AddEnrollmentAsync(new Enrollment()
                {
                    ClientFirstname = ClientFirstname,
                    ClientPhoneNumber = ClientPhoneNumber,
                    DateTime = dateTime,
                    Description = Description,
                    CreationDateTime = DateTime.Now
                });
            }
            else
            {
                Enrollment.ClientFirstname = ClientFirstname;
                Enrollment.ClientPhoneNumber = ClientPhoneNumber;
                Enrollment.DateTime = dateTime;
                Enrollment.Description = Description;
                Enrollment.EditDateTime = DateTime.Now;

                await enrollmentService.EditEnrollmentAsync(Enrollment);
                await serviceManager.RemoveAllEnrollmentWorkerServicesAsync(Enrollment.Id);
            }

            var enrollmentWorkerServices = new List<EnrollmentWorkerService>();

            EnrollmentServices.ForEach(EnrollmentService =>
            {
                enrollmentWorkerServices.Add(new EnrollmentWorkerService()
                {
                    EnrollmentId = Enrollment.Id,
                    ServiceId = EnrollmentService.Id,
                    WorkerId = EnrollmentService.WorkerId
                });
            });

            await serviceManager.AddEnrollmentWorkerServicesAsync(enrollmentWorkerServices);

            return await base.SaveAsync();
        }

        public async Task OnCloseExecuteAsync()
        {
            await this.CancelAndCloseViewModelAsync();
        }
    }
}
