using DAL.Compartido.Models;
using Entities;
using Mapper.Transacciones.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Transacciones
{
    public static class TransaccionMapper
    {
        public static TransaccionModel ToModel(this Transaccion transaccion)
        {
            if (transaccion is Compra compra)
            {
                return compra.ToModel();
            }
            else if (transaccion is Venta venta)
            {
                throw new NotImplementedException(venta.GetType().Name + " no está implementado en TransaccionMapper.");
            }
            throw new InvalidOperationException("Tipo de transacción no soportado.");
        }
    }
}
