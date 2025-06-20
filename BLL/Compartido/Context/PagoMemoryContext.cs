using BLL.Compartido.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compartido.Context
{
    public class PagoMemoryContext : IPagoContext
    {
        private readonly Transaccion transaccion;

        public PagoMemoryContext(Transaccion transaccion)
        {
            this.transaccion = transaccion;
        }

        public event EventHandler? OnOperationFinished;

        public void Add(Pago pago)
        {
            if (transaccion.Pagos is null)
            {
                transaccion.Pagos = new List<Pago>();
            }
            transaccion.Pagos.Add(pago);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }


        public List<Pago> GetAll()
        {
            if (transaccion.Pagos is null)
            {
                return new List<Pago>();
            }
            return transaccion.Pagos;
        }

        public void Remove(Pago pago)
        {
            if (transaccion.Pagos is null)
            {
                return;
            }
            transaccion.Pagos = transaccion.Pagos.Where(x => x.Id != pago.Id).ToList();
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(Pago pago)
        {
            if (transaccion.Pagos is null)
            {
                return;
            }

            var existingPago = transaccion.Pagos.FirstOrDefault(x => x.Id == pago.Id);
            if (existingPago is not null)
            {
                existingPago.Cantidad = pago.Cantidad;
                existingPago.Tipo = pago.Tipo;
                existingPago.Fecha = pago.Fecha;
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}
