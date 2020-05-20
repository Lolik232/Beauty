using Beauty.Core.Interfaces;
using Beauty.Data.Models;
using Catel;
using Catel.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IPositionService positionService;
        private readonly IServiceManager serviceManager;

        public override string Title => "Настройки приложения";

        public ICollection<Position> Positions { get; set; }
        public ICollection<Service> Services { get; set; }

        public SettingsViewModel(IPositionService positionService, IServiceManager serviceManager)
        {
            Argument.IsNotNull(() => positionService);
            Argument.IsNotNull(() => serviceManager);

            this.positionService = positionService;
            this.serviceManager = serviceManager;
        }

        protected override async Task InitializeAsync()
        {
            var positions = await positionService.GetPositionsAsync();
            Positions = new ObservableCollection<Position>(positions);

            var services = await serviceManager.GetServicesAsync();
            Services = new ObservableCollection<Service>(services);

            await base.InitializeAsync();
        }
    }
}
