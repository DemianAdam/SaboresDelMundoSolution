using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Entities;
using DAL;
using BLL;
using BLL.Productos.Contracts;
namespace Console_UI
{
    internal class Program
    {

        static void Main(string[] args)
        {





            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                }).ConfigureServices((context, services) =>
                {
                    IConfiguration config = context.Configuration;

                    // Register services
                    services.AddSingleton<IConfiguration>(config); // Pass to DAL
                    services.AddDAL(config);
                    services.AddBLL(config);
                })
            .Build();

            var repo = host.Services.GetRequiredService<IProductoService>();

            List<Producto> productos = ((IGetAll<Producto>)repo).GetAll();

            foreach (var item in productos)
            {
                Console.WriteLine(item.Nombre);
            }
        }
    }
}
