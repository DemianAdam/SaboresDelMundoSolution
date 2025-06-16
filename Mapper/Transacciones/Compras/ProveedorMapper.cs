using DAL.Compra.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Transacciones.Compras
{
    public static class ProveedorMapper
    {
        public static List<Proveedor> ToProveedores(this List<ProveedorModel> proveedoresModels)
        {
            return proveedoresModels.Select(pm => pm.ToProveedor()).ToList();
        }
        public static Proveedor ToProveedor(this ProveedorModel proveedorModel)
        {
            return new Proveedor
            {
                Id = proveedorModel.Id,
                Nombre = proveedorModel.Nombre,
            };
        }

        public static ProveedorModel ToModel(this Proveedor proveedor)
        {
            return new ProveedorModel
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
            };
        }
    }
}
