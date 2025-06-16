using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Contracts;

namespace WinForm_UI.Services
{
    internal class FormFactoryService : IFormFactoryService
    {
        private readonly IServiceProvider _serviceProvider;

        public FormFactoryService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateForm<T>(params object[] parameters) where T : Form
        {
            T? form = _serviceProvider.GetService<T>();

            if (form is null)
            {
                return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), parameters);
            }

            return form;           
        }
    }
}
