using Entities;
using Interfaces;

namespace BLL.Compras.Contracts
{
    public interface IDetalleCompraContext : IContext
    {
        public event EventHandler? OnOperationFinished;
        void Add(DetalleCompra detalleCompra);
        List<DetalleCompra> GetAll();
        void Remove(DetalleCompra detalleCompra);
        void Update(DetalleCompra detalleCompra);
    }
}
