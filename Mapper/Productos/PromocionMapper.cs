using DAL.Productos.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Productos
{
    public static class PromocionMapper
    {
        public static Promocion ToPromocion(this Producto producto)
        {
            Promocion promocion = new Promocion
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Tipo = producto.Tipo.Clone(),
                SubProductos = producto.SubProductos?.Select(sp => sp.Clone()).ToList(),
                CantidadTipoProductos = new List<CantidadTipoProducto>()
            };

            return promocion;
        }
        public static Promocion ToPromocion(this ProductoModel producto, List<TipoProductoModel> tipos, List<PromocionCantidadTipoProductoModel> promocionRelations, TipoProducto tipoProducto)
        {
            Promocion promocion = new Promocion
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Tipo = tipoProducto,
            };

            promocion.CantidadTipoProductos = ToPromocionCantidadProductos(promocion, tipos, promocionRelations);


            return promocion;
        }
        public static List<PromocionCantidadTipoProductoModel>? GetPromocionCantidadProductosModel(this Producto producto)
        {
            if (producto is not Promocion promocion)
            {
                return null;
            }

            return promocion.CantidadTipoProductos?.Select(ctp => new PromocionCantidadTipoProductoModel
            {
                ProductoId = producto.Id,
                TipoProductoId = ctp.TipoProducto.Id,
                Cantidad = ctp.Cantidad
            }).ToList();
        }

        private static List<CantidadTipoProducto> ToPromocionCantidadProductos(Promocion promocion, List<TipoProductoModel> tipos, List<PromocionCantidadTipoProductoModel> promocionRelations)
        {
            Dictionary<int, TipoProductoModel> tiposDict = tipos.ToDictionary(t => t.Id);
            List<CantidadTipoProducto> cantidadTipoProductos = new List<CantidadTipoProducto>();
            foreach (var relation in promocionRelations.Where(r => r.ProductoId == promocion.Id))
            {
                if (!tiposDict.TryGetValue(relation.TipoProductoId, out var tipoModel))
                {
                    throw new ArgumentException($"TipoProductoId {relation.TipoProductoId} no encontrado en la lista de tipos de producto.");
                }
                //cantidadTipoProductos[tipoModel.ToTipoProducto()] = relation.Cantidad;
                CantidadTipoProducto newCantidadTipoProducto = new CantidadTipoProducto
                {
                    TipoProducto = tipoModel.ToTipoProducto(),
                    Cantidad = relation.Cantidad
                };

                CantidadTipoProducto? cantidadTipoProducto = cantidadTipoProductos
                    .FirstOrDefault(ctp => ctp.TipoProducto.Id == newCantidadTipoProducto.TipoProducto.Id);

                if (cantidadTipoProducto is null)
                {
                    cantidadTipoProductos.Add(newCantidadTipoProducto);
                }
                else
                {
                    cantidadTipoProducto.Cantidad += newCantidadTipoProducto.Cantidad;
                }
            }
            return cantidadTipoProductos.ToList();
        }
    }
}
