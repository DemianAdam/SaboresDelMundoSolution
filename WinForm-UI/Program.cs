using BLL;
using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinForm_UI.Infrastructure;
using WinForm_UI.Productos;
using WinForm_UI.Forms.Compras;
using Entities;
using WinForm_UI.Contracts;

namespace WinForm_UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                }).ConfigureServices((context, services) =>
                {
                    // Access config if needed
                    IConfiguration config = context.Configuration;

                    // Register services
                    services.AddSingleton<IConfiguration>(config); // Pass to DAL
                    services.AddDAL(config);
                    services.AddBLL(config);
                    services.AddForms();
                })
            .Build();

            var factory = host.Services.GetRequiredService<IFormFactoryService>();

            object[] objects =
                [
              //  new Compra()

                ];

            Application.Run(factory.CreateForm<Principal>(objects));
        }
    }
}