using Beauty.Core.DTOs;
using Beauty.WPF.Enums;
using Beauty.WPF.Infrastructure;
using Catel.Logging;
using Catel.MVVM;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class EnrollmentDetailsViewModel : ViewModelBase
    {
        private static readonly ILog log;

        public Command CancelCommand { get; set; }

        static EnrollmentDetailsViewModel()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public EnrollmentDetailsViewModel()
        {
            CancelCommand = new Command(OnCancelExecute);
        }

        public EnrollmentDetailsViewModel(EnrollmentDTO enrollment) : this()
        {
            Title = $"Редактирование заявки №{enrollment.Id}";
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
        }

        public void OnCancelExecute()
        {
            Controller.Application.GoToView(ApplicationViews.EnrollmentView);
        }
    }
}
