using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Compartido.Models;
using DAL.Compra.Models;
using DAL.Configuraciones.Models;
using DAL.Insumos.Models;
using Entities.Transacciones.Compras;
using Mapper.Compartido;

namespace Mapper.Transacciones.Compras
{
    public static class CompraMapper
    {
        public static List<Compra> ToCompras(this List<CompraModel> compraModels, List<DetalleCompraModel> detalleCompraModels, List<InsumoModel> insumoModels, List<TipoInsumoModel> tipoInsumoModels, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<ProveedorModel> proveedorModels, List<PagoModel> pagos)
        {
            return compraModels.Select(compraModel => ToCompra(compraModel, detalleCompraModels, insumoModels, tipoInsumoModels, unidadDeMedidaModels, proveedorModels,pagos)).ToList();
        }
        public static Compra ToCompra(CompraModel compraModel, List<DetalleCompraModel> detalleCompraModels,List<InsumoModel> insumoModels,List<TipoInsumoModel> tipoInsumoModels,List<UnidadDeMedidaModel> unidadDeMedidaModels,List<ProveedorModel> proveedorModels, List<PagoModel> pagos)
        {
            return new Compra
            {
                Id = compraModel.Id,
                Proveedor = proveedorModels.FirstOrDefault(p => p.Id == compraModel.ProveedorId)?.ToProveedor(),
                Fecha = compraModel.Fecha,
                Detalles = detalleCompraModels.Where(d => d.CompraId == compraModel.Id).ToList().ToDetalles(insumoModels, tipoInsumoModels, unidadDeMedidaModels),
                Pagos = pagos.Where(p => p.CompraId == compraModel.Id).ToList().ToPagos(),
                MontoTotal = compraModel.Total
            };
        }
        public static CompraModel ToModel(this Compra compra)
        {
            return new CompraModel
            {
                Id = compra.Id,
                ProveedorId = compra.Proveedor?.Id,
                Fecha = compra.Fecha,
                Total = compra.MontoTotal
            };
        }
    }
}
