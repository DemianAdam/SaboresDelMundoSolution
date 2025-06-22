using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Services;
using WinForm_UI.Productos;
using WinForm_UI.Contracts;
using Interfaces;


namespace WinForm_UI.Infrastructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddForms(this IServiceCollection services)
        {
            services.AddSingleton<IFormFactoryService, FormFactoryService>();
            services.AddSingleton<Principal>();
            return services;
        }
    }
}
