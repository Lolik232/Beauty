using Beauty.Core.Interfaces;
using Beauty.Data.Models;
using Catel.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class EnrollmentViewModel : ViewModelBase
    {
        private readonly IEnrollmentService enrollmentService;

        public ICollection<Enrollment> Enrollments { get; set; }
        public Enrollment SelectedEnrollment { get; set; }

        public EnrollmentViewModel(IEnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
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
