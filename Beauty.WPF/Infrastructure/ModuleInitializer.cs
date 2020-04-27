using Beauty.Core.Interfaces;
using Beauty.Core.Services;
using Beauty.Data.Interfaces;
using Beauty.Data.UnitOfWorks;
using Beauty.WPF.ViewModels;
using Catel.IoC;

namespace Beauty.WPF.Infrastructure
{
    public static class ModuleInitializer
    {
        public static void Initialize()
        {
            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<ApplicationViewModel>(RegistrationType.Singleton);
            serviceLocator.RegisterType<IUnitOfWork, StandartUnitOfWork>(RegistrationType.Transient);
            serviceLocator.RegisterType<ICryptographyService, MD5CryptographyService>(RegistrationType.Transient);
            serviceLocator.RegisterType<ILoginService, LoginService>(RegistrationType.Transient);
            serviceLocator.RegisterType<IWorkerService, WorkerService>(RegistrationType.Transient);
            serviceLocator.RegisterType<IEnrollmentService, EnrollmentService>(RegistrationType.Transient);
            serviceLocator.RegisterType<IServiceManager, ServiceManager>(RegistrationType.Transient);
        }
    }
}
