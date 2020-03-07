using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using Beauty.Data.UnitOfWorks;
using Beauty.WPF.ViewModels;
using Beauty.WPF.Windows;
using Catel.ApiCop;
using Catel.ApiCop.Listeners;
using Catel.IoC;
using Catel.Logging;
using System.Security.Cryptography;
using System.Windows;

namespace Beauty.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog log;

        static App()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            #if DEBUG
            LogManager.AddDebugListener();
            #endif

            log.Info("Запуск приложения");

            log.Info("Регистрация зависимостей");
            ServiceLocator.Default.RegisterType<IUnitOfWork, UnitOfWork>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<ICryptographyService, MD5CryptographyService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<ILoginService, LoginService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<IWorkerService, WorkerService>(RegistrationType.Transient);

            log.Info("Вызов base.OnStartup(e)");
            base.OnStartup(e);

            log.Info("Запуск главного окна приложения");
            Current.MainWindow = new ApplicationWindow();
            Current.MainWindow.Show();

            log.Info("Регистрация модели представления главного окна приложения");
            var window = Current.MainWindow as ApplicationWindow;
            var applicationViewModel = window.ViewModel as ApplicationViewModel;
            ServiceLocator.Default.RegisterInstance(applicationViewModel);
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