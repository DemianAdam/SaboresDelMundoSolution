using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compartido.Contracts
{
    public interface IPagoService : IGetAll<Pago>
    {
        public event EventHandler? OnOperationFinished;
        void Insert(Pago pago, Transaccion transaccion);
        void Remove(Pago pago);
        void Update(Pago pago, Transaccion transaccion);
        public List<Pago> GetAllByTransactionId(Transaccion transaccion);

    }
}
