using DAL.Productos.Models;

namespace DAL.Productos
{
    public interface IProductoUnitOfWork
    {
        List<ProductoModel> GetAllProductoModel();
        List<ProductoSubProductoModel> GetAllProductoSubProductoModels();
        List<PromocionCantidadTipoProductoModel> GetAllPromocionCantidadProductosModels();
        List<TipoProductoModel> GetAllTiposProductos();
        void Insert(ProductoModel producto, List<ProductoSubProductoModel>? productoSubProductoModels = null, List<PromocionCantidadTipoProductoModel>? promocionCantidadProductosModels = null);
        void Remove(ProductoModel producto);
        void Update(ProductoModel producto, List<ProductoSubProductoModel>? productoSubProductoModels = null, List<PromocionCantidadTipoProductoModel>? promocionCantidadProductosModels = null);

        void Insert(TipoProductoModel tipoProducto);
        void Remove(TipoProductoModel tipoProducto);
        void Update(TipoProductoModel tipoProducto);
    }
}
