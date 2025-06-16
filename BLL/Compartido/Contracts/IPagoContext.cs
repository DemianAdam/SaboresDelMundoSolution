using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compartido.Contracts
{
    public interface IPagoContext : IContext
    {
        public event EventHandler? OnOperationFinished;
        void Add(Pago pago);
        List<Pago> GetAll();
        void Remove(Pago pago);
        void Update(Pago pago);
    }
}
