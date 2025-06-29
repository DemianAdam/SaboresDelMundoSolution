using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Productos
{
    public class Promocion : Producto
    {
        public List<CantidadTipoProducto>? CantidadTipoProductos { get; set; }
        public override Promocion Clone()
        {
            return new Promocion
            {
                Id = Id,
                Nombre = Nombre,
                Precio = Precio,
                Tipo = Tipo.Clone(),
                SubProductos = SubProductos?.Select(sp => sp.Clone()).ToList(),
                CantidadTipoProductos = CantidadTipoProductos?.Select(ctp => ctp.Clone()).ToList()

            };
        }

        public bool RemoveAllTipoProductoById(TipoProducto tipoProducto)
        {
            if (CantidadTipoProductos is null)
            {
                return false;
            }
            CantidadTipoProductos = CantidadTipoProductos.FindAll(ctp => ctp.TipoProducto.Id != tipoProducto.Id);
            return true;
        }

        public void AddOrUpdateTipoProducto(TipoProducto tipoProducto, int cantidad)
        {

            if (CantidadTipoProductos is null)
            {
                return;
            }

            CantidadTipoProducto? cantidadTipoProducto = CantidadTipoProductos
                            .FirstOrDefault(ctp => ctp.TipoProducto.Id == tipoProducto.Id);
            if (cantidadTipoProducto is null)
            {
                CantidadTipoProductos.Add(new CantidadTipoProducto
                {
                    TipoProducto = tipoProducto.Clone(),
                    Cantidad = cantidad
                });
            }
            else
            {
                cantidadTipoProducto.Cantidad = cantidad;
            }
        }
    }
}
