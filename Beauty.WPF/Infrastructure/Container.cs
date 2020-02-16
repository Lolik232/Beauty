using Catel.IoC;
using Catel.Logging;

namespace Beauty.WPF.Infrastructure
{
    public static class Container
    { 
        public static TImplementation Get<TImplementation>()
        {
            return ServiceLocator.Default.ResolveType<TImplementation>();
        }
    }
}