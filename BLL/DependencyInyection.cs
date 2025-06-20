using BLL.Compras.Contracts;
using BLL.Compras.Services;
using BLL.Compartido.Contracts;
using BLL.Compartido.Services;
using BLL.Productos.Contracts;
using BLL.Productos.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLL.Insumos.Contracts;
using BLL.Insumos.Services;
using BLL.Configuraciones.Contracts;
using BLL.Configuraciones.Services;
using BLL.Ingredientes.Contracts;
using BLL.Ingredientes.Services;


namespace BLL
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddBLL(this IServiceCollection services, IConfiguration configuration)
        {
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


            return services;
        }
    }
}
