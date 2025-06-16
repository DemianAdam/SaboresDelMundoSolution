using DAL.Productos.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Productos
{
    public static class TipoProductoMapper
    {
        public static List<TipoProducto> ToTiposProductos(this List<TipoProductoModel> tipoProductoModels)
        {
            return tipoProductoModels.Select(tp => tp.ToTipoProducto()).ToList();
        }
        public static TipoProducto ToTipoProducto(this TipoProductoModel tipoProductoModel)
        {
            return new TipoProducto
            {
                Id = tipoProductoModel.Id,
                Tipo = tipoProductoModel.Tipo
            };
        }
        public static TipoProductoModel ToModel(this TipoProducto tipoProducto)
        {
            return new TipoProductoModel
            {
                Id = tipoProducto.Id,
                Tipo = tipoProducto.Tipo
            };
        }
    }
}
