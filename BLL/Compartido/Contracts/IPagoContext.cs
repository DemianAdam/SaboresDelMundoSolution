using Entities;
using Interfaces;

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
