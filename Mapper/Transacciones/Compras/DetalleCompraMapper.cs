using DAL.Compra.Models;
using DAL.Configuraciones.Models;
using DAL.Insumos.Models;
using Entities.Compartido;
using Entities.Configuraciones;
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
            UnidadDeMedida? unidadDeMedida = unidadDeMedidaModels.FirstOrDefault(u => u.Id == detalleCompraModel.UnidadDeMedidaId)?.ToUnidadDeMedida();
            if (unidadDeMedida == null)
            {
                throw new ArgumentException($"Unidad de medida con ID {detalleCompraModel.UnidadDeMedidaId} no encontrada.");
            }
            Peso peso = new Peso
            {
                Valor = detalleCompraModel.Cantidad,
                UnidadDeMedida = unidadDeMedida
            };
            return new DetalleCompra
            {
                Id = detalleCompraModel.Id,
                Insumo = insumoModels.First(i => i.Id == detalleCompraModel.InsumoId).ToInsumo(tipoInsumoModels),
                Peso = peso,
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
                UnidadDeMedidaId = detalleCompra.Peso.UnidadDeMedida.Id,
                Cantidad = detalleCompra.Peso.Valor,
                Costo = detalleCompra.Costo,
                CompraId = compra.Id
            };
        }
    }
}
