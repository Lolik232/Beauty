using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.Data.Interfaces;
using Beauty.Data.UnitOfWorks;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.ViewModels;
using Beauty.WPF.Windows;
using Catel.ApiCop;
using Catel.ApiCop.Listeners;
using Catel.IoC;
using Catel.Logging;
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
            {
                log.Info("Подключение логов Catel'a");
                LogManager.AddDebugListener();
                log.Info("Логи Catel'a успешно подключены");
            }
            #endif

            log.Info("Запуск приложения");

            log.Info("Запуск главного окна приложения");
            var window = new ApplicationWindow();
            Current.MainWindow = window;
            Current.MainWindow.Show();
            log.Info("Главное окно приложения успешно запущено");

            log.Info("Регистрация главного окна приложения");
            var applicationViewModel = window.ViewModel as ApplicationViewModel;
            Container.RegisterInstance(applicationViewModel);
            log.Info("Главное окно приложения успешно зарегистрировано");

            log.Info("Регистрация зависимостей, связанных с базой данных");
            Container.RegisterType<IUnitOfWork, StandartUnitOfWork>(RegistrationType.Transient);
            log.Info("Зависимости, связанные с базой данных, успешно зарегистрированы");

            log.Info("Регистрация сервисов");
            Container.RegisterType<ICryptographyService, MD5CryptographyService>(RegistrationType.Transient);
            Container.RegisterType<ILoginService, LoginService>(RegistrationType.Transient);
            Container.RegisterType<IWorkerService, WorkerService>(RegistrationType.Transient);
            Container.RegisterType<IEnrollmentService, EnrollmentService>(RegistrationType.Transient);
            log.Info("Сервисы успешно зарегистрированы");

            log.Info("Вызов base.OnStartup(e)");
            base.OnStartup(e);
            log.Info("Метод base.OnStartup(e) успешно вызван");

            log.Info("Приложение успешно запущено");
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