using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Services
{
    internal class ContextFactory : IContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T CreateContext<T>(params object[] parameters) where T : IContext
        {
            return ActivatorUtilities.CreateInstance<T>(_serviceProvider, parameters);
        }
    }
}
