using Beauty.Core.Interfaces;
using Beauty.Data.Models;
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

        private readonly IEnrollmentService enrollmentService;
        private readonly IMessageService messageService;

        public ICollection<Enrollment> Enrollments { get; set; }
        public Enrollment SelectedEnrollment { get; set; }

        static EnrollmentViewModel()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public EnrollmentViewModel(IEnrollmentService enrollmentService, IMessageService messageService)
        {
            this.enrollmentService = enrollmentService;
            this.messageService = messageService;
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(async () =>
            {
                var enrollments = await enrollmentService.GetRelevantEnrollmentsAsync();
                Enrollments = new ObservableCollection<Enrollment>(enrollments);

                SelectedEnrollment = Enrollments.First();
            });

            await base.InitializeAsync();
        }
    }
}
