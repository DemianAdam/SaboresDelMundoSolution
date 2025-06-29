using BLL.Compartido.Contracts;
using Entities.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compartido.Context
{
    public class PagoDbContext : IPagoContext
    {
        private readonly IPagoService pagoService;
        private readonly Transaccion transaccion;

        public PagoDbContext(IPagoService pagoService, Transaccion transaccion)
        {
            this.pagoService = pagoService;
            this.transaccion = transaccion;
            pagoService.OnOperationFinished += (sender, e) => OnOperationFinished?.Invoke(sender, e);
        }

        public event EventHandler? OnOperationFinished;

        public void Add(Pago pago)
        {
            pagoService.Insert(pago, transaccion);
        }

        public List<Pago> GetAll()
        {
           return pagoService.GetAllByTransactionId(transaccion);
        }

        public void Remove(Pago pago)
        {
            pagoService.Remove(pago);
        }

        public void Update(Pago pago)
        {
            pagoService.Update(pago, transaccion);
        }
    }
}
