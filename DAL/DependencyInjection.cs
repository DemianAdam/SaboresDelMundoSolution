using DAL.Compartido.Contracts;
using DAL.Compartido.Repositories;
using DAL.Compra;
using DAL.Compra.Contracts;
using DAL.Compra.Repositories;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Repositories;
using DAL.Insumos;
using DAL.Insumos.Contracts;
using DAL.Insumos.Repositories;
using DAL.Productos;
using DAL.Productos.Contracts;
using DAL.Productos.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnidadDeMedidaRepository, UnidadDeMedidaRepository>();
            services.AddTransient<ITipoInsumoRepository, TipoInsumoRepository>();
            services.AddTransient<IInsumoRepository, InsumoRepository>();
            services.AddTransient<IInsumoUnitOfWork, InsumoUnitOfWork>();
            services.AddTransient<IDetalleCompraRepository, DetalleCompraRepository>();
            services.AddTransient<ICompraRepository, CompraRepository>();
            services.AddTransient<IProveedorRepository, ProveedorRepository>();
            services.AddTransient<ICompraUnitOfWork, CompraUnitOfWork>();
            services.AddTransient<IPagoRepository, PagoRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IProductoSubProductoRepository, ProductoSubProductoRepository>();
            services.AddTransient<IPromocionCantidadProductosRepository, PromocionCantidadProductosRepository>();
            services.AddTransient<ITipoProductoRepository, TipoProductoRepository>();
            services.AddTransient<IProductoUnitOfWork, ProductoUnitOfWork>();


            return services;
        }
    }
}
