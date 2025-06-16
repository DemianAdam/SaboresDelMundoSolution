using DAL.Productos;
using DAL.Productos.Models;
using Entities;

namespace Mapper.Productos
{
    public static class ProductoMapper
    {
        public static ProductoModel ToModel(this Producto producto)
        {
            return new ProductoModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                TipoProductoId = producto.Tipo.Id
            };
        }
        public static List<Producto> ToProductos(this List<ProductoModel> productos, List<TipoProductoModel> tipos, List<PromocionCantidadTipoProductoModel> promocionRelations)
        {
            return productos.Select(p => p.ToProducto(tipos, promocionRelations)).ToList();
        }
        public static Producto ToProducto(this ProductoModel producto, List<TipoProductoModel> tipos, List<PromocionCantidadTipoProductoModel> promocionRelations)
        {
            TipoProducto? tipoProducto = tipos.Find(t => t.Id == producto.TipoProductoId)?.ToTipoProducto();

            if (tipoProducto == null)
            {
                throw new ArgumentException("TipoProductoId no encontrado en la lista de tipos de producto.");
            }

            if (tipoProducto.Tipo == "Promocion")
            {
                return PromocionMapper.ToPromocion(producto, tipos, promocionRelations, tipoProducto);
            }

            return new Producto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Tipo = tipoProducto,
            };
        }
        public static List<Producto> AssignSubProductos(this List<Producto> productos, List<ProductoSubProductoModel> subProductoRelations)
        {
            var productosDict = productos.ToDictionary(p => p.Id);

            foreach (var relation in subProductoRelations)
            {
                if (productosDict.TryGetValue(relation.ProductoID, out var producto) &&
                    productosDict.TryGetValue(relation.SubProductoId, out var subProducto))
                {
                    if (producto.SubProductos == null)
                    {
                        producto.SubProductos = new List<Producto>();
                    }
                    producto.SubProductos.Add(subProducto);
                }
            }
            return productos;
        }

        

        public static List<ProductoSubProductoModel>? GetSubProductosModel(this Producto producto)
        {
            return producto.SubProductos?.Select(sp => new ProductoSubProductoModel
            {
                ProductoID = producto.Id,
                SubProductoId = sp.Id
            }).ToList();
        }
        
        
    }
}
