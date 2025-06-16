using DAL.Compartido.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Compartido
{
    public static class PagoMapper
    {
        public static List<Pago> ToPagos(this List<PagoModel> pagoModels)
        {
            return pagoModels.Select(p => new Pago
            {
                Id = p.Id,
                Fecha = p.Fecha,
                Cantidad = p.Cantidad,
                Tipo = (TipoPago)p.TipoPago
            }).ToList();
        }
        public static List<PagoModel> ToModels(this List<Pago> pagos, Transaccion transaccion)
        {
            return pagos.Select(p => p.ToModel(transaccion)).ToList();
        }
        public static PagoModel ToModel(this Pago pago, Transaccion? transaccion = null)
        {
            int? compraId = null;
            int? ventaId = null;
            if (transaccion is Compra compra)
            {
                compraId = compra.Id;
            }
            else if (transaccion is Venta venta)
            {
                ventaId = venta.Id;
            }

            return new PagoModel
            {
                Id = pago.Id,
                Fecha = pago.Fecha,
                Cantidad = pago.Cantidad,
                TipoPago = (int)pago.Tipo,
                CompraId = compraId,
                VentaId = ventaId
            };
        }

    }
}
