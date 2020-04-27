using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.Data.Interfaces;
using Beauty.Data.UnitOfWorks;
using Beauty.WPF.Interfaces;
using Beauty.WPF.ViewModels;
using Beauty.WPF.Windows;
using Catel.ApiCop;
using Catel.ApiCop.Listeners;
using Catel.IoC;
using Catel.Logging;
using Catel.Services;
using System.Windows;

namespace Beauty.WPF
{
    public partial class App : Application
    {
        private static readonly ILog log;

        static App()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new ApplicationWindow();
            Current.MainWindow = window;
            Current.MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var listener = new ConsoleApiCopListener();

            ApiCopManager.AddListener(listener);
            ApiCopManager.WriteResults();

            base.OnExit(e);
        }
    }
}