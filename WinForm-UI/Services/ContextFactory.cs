using BLL.Compartido.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Contracts;

namespace WinForm_UI.Services
{
    internal class ContextFactory : IContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T CreateInstance<T>(params object[] parameters) where T : IContext
        {
            return ActivatorUtilities.CreateInstance<T>(_serviceProvider, parameters);
        }
    }
}
