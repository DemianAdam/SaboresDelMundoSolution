using DAL.Compra.Models;
using DAL.Configuraciones.Models;
using DAL.Insumos.Models;
using Entities.Transacciones.Compras;
using Mapper.Configuraciones;
using Mapper.Insumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Transacciones.Compras
{
    public static class DetalleCompraMapper
    {
        public static List<DetalleCompra> ToDetalles(this List<DetalleCompraModel> detalleCompraModels, List<InsumoModel> insumoModels, List<TipoInsumoModel> tipoInsumoModels, List<UnidadDeMedidaModel> unidadDeMedidaModels)
        {
            return detalleCompraModels.Select(dcm => dcm.ToDetalleCompra(insumoModels, tipoInsumoModels, unidadDeMedidaModels)).ToList();
        }
        public static DetalleCompra ToDetalleCompra(this DetalleCompraModel detalleCompraModel, List<InsumoModel> insumoModels, List<TipoInsumoModel> tipoInsumoModels, List<UnidadDeMedidaModel> unidadDeMedidaModels)
        {
            return new DetalleCompra
            {
                Id = detalleCompraModel.Id,
                Insumo = insumoModels.First(i => i.Id == detalleCompraModel.InsumoId).ToInsumo(tipoInsumoModels),
                Unidad = unidadDeMedidaModels.First(u => u.Id == detalleCompraModel.UnidadDeMedidaId).ToUnidadDeMedida(),
                Cantidad = detalleCompraModel.Cantidad,
                Costo = detalleCompraModel.Costo
            };
        }
        public static List<DetalleCompraModel> ToModels(this List<DetalleCompra> detalleCompras, Compra compra)
        {
            return detalleCompras.Select(dc => dc.ToModel(compra)).ToList();
        }
        public static DetalleCompraModel ToModel(this DetalleCompra detalleCompra, Compra compra)
        {
            return new DetalleCompraModel
            {
                Id = detalleCompra.Id,
                InsumoId = detalleCompra.Insumo.Id,
                UnidadDeMedidaId = detalleCompra.Unidad.Id,
                Cantidad = detalleCompra.Cantidad,
                Costo = detalleCompra.Costo,
                CompraId = compra.Id
            };
        }
    }
}
