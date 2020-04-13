using Beauty.Data.Models;
using Catel.IoC;
using Catel.MVVM;
using Catel.MVVM.Views;
using System;
using System.Linq;

namespace Beauty.WPF.Infrastructure
{
    public static class Container
    {
        public static void RegisterInstance<TImplementation>(TImplementation instance, object tag = null)
        {
            ServiceLocator.Default.RegisterInstance(instance, tag);
        }

        public static void RegisterType<TImplementation>(RegistrationType registrationType = RegistrationType.Singleton)
        {
            ServiceLocator.Default.RegisterType<TImplementation>(registrationType);
        }

        public static void RegisterType<TInterface, TImplementation>(RegistrationType registrationType = RegistrationType.Singleton, bool registerIfAlreadyRegistered = true)
            where TImplementation : TInterface
        {
            ServiceLocator.Default.RegisterType<TInterface, TImplementation>(registrationType, registerIfAlreadyRegistered);
        }

        public static TImplementation Get<TImplementation>(object tag = null)
        {
            return ServiceLocator.Default.ResolveType<TImplementation>(tag);
        }

        public static object Get(Type implementationType, object tag = null)
        {
            return ServiceLocator.Default.ResolveType(implementationType, tag);
        }

        public static TImplementation GetWithParameters<TImplementation>(object[] parameters, object tag = null)
        {
            return ServiceLocator.Default.ResolveTypeUsingParameters<TImplementation>(parameters, tag);
        }

        public static object GetWithParameters(Type implementationType, object[] parameters, object tag = null)
        {
            return ServiceLocator.Default.ResolveTypeUsingParameters(implementationType, parameters, tag);
        }

        public static void RemoveType<TImplementation>(object tag = null)
        {
            ServiceLocator.Default.RemoveType<TImplementation>(tag);
        }
    }
}