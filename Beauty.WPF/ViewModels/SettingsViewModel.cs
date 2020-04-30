using Catel.MVVM;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public override string Title => "Настройки приложения";

        public SettingsViewModel()
        {

        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
        }
    }
}
