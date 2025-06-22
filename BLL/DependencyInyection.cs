using BLL.Compartido.Contracts;
using BLL.Compartido.Services;
using BLL.Compras.Contracts;
using BLL.Compras.Services;
using BLL.Compras.Validators;
using BLL.Configuraciones.Contracts;
using BLL.Configuraciones.Services;
using BLL.Ingredientes.Contracts;
using BLL.Ingredientes.Services;
using BLL.Insumos.Contracts;
using BLL.Insumos.Services;
using BLL.Productos.Contracts;
using BLL.Productos.Services;
using BLL.Services;
using Entities;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BLL
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBus, EventBus>();
            services.AddSingleton<IContextFactory, ContextFactory>();
            services.AddTransient<IUnidadDeMedidaService, UnidadDeMedidaService>();
            services.AddTransient<ITipoInsumoService, TipoInsumoService>();
            services.AddTransient<IInsumoService, InsumoService>();
            services.AddTransient<ICompraService, CompraService>();
            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IPagoService, PagoService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ITipoProductoService, TipoProductoService>();
            services.AddTransient<IIngredienteService, IngredienteService>();
            services.AddTransient<IRecetaService, RecetaService>();
            services.AddTransient<IRecetaCantidadService, RecetaCantidadService>();
            services.AddTransient<IDetalleCompraService, DetalleCompraService>();


            return services;
        }
    }
}
