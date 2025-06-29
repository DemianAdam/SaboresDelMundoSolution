using Entities.Transacciones.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Contracts
{
    public interface IDetalleCompraService : IGetAll<DetalleCompra>
    {
        public event EventHandler? OnOperationFinished;
        void Insert(DetalleCompra detalleCompra, Compra compra);
        void Remove(DetalleCompra detalleCompra);
        void Update(DetalleCompra detalleCompra, Compra compra);
        List<DetalleCompra> GetAllByPurchaseId(Compra compra);
    }
}
